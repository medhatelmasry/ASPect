import React, { useEffect, useState } from "react";
import axios from "axios";
import { useHistory } from "react-router-dom";
import * as Yup from "yup";
import { LinkContainer } from "react-router-bootstrap";
import { Field, useFormik, FormikProvider, Form } from "formik";
import { Button, Alert, Row } from "react-bootstrap";
import FormContainer from "../components/FormContainer";

const CreateProgressUpdate = (props) => {
  const schema = Yup.object({
    lastWeekActivity: Yup.string()
      .required("Must fill out last weeks activities"),
    nextWeekActivity: Yup.string()
      .required("Must fill out next weeks activities"),
  });
  const config = {
    headers: {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
    },
  };
  let id = props.match.params.projectId;

  const authenticated =
    localStorage.getItem("id") &&
      localStorage.getItem("token") &&
      localStorage.getItem("expiration")
      ? true
      : false;

  const history = useHistory();

  if (authenticated) {
    console.log("logged in");
  } else {
    console.log("not logged in");
    history.push("/login");
  }
  const [error, setError] = useState("");
  const [showAlert, setShowAlert] = useState(false);
  const formik = useFormik({
    initialValues: {
      date: "",
      lastWeekActivity:"",
      nextWeekActivity:"",
      issues: "",
      projectId: id,
      complete: false,
    },
    onSubmit: async (values) => {
      console.log(values);
      try {
        await axios.post(
          `https://localhost:5001/api/progressupdate`,
          values,
          config
        );
        history.push("/projectstatus/" + id);
        console.log("saved changes");
      } catch (error) {
        console.log(error);
      }
    },
    validationSchema: schema, 
  });

  return (
    <FormikProvider value={formik}>
      <FormContainer>
        <Row className="text-center">
          <h1 className="mb-4 mx-auto">Create New Status Update</h1>
        </Row>

        {error && showAlert && (
          <Alert
            variant="danger"
            onClose={() => setShowAlert(false)}
            dismissible
          >
            {error}
          </Alert>
        )}

        <Form> 
          <label htmlFor="date">Week Starting</label>
          <br/>
          <Field type="date" id="date" name="date"/>
          <br/>
          <label htmlFor="lastWeekActivity">Last Week Activity</label>
          <br/>
          <Field
            as="textarea"
            id="lastWeekActivity"
            name="lastWeekActivity"
          />
          <br/>
          <label htmlFor="nextWeekActivity">Next Week Activity</label>
          <br/>
          <Field
            as="textarea"
            id="nextWeekActivity"
            name="nextWeekActivity"
          />
          <br/>
          <label htmlFor="issues">Issues</label>
          <br/>
          <Field
            as="textarea"
            id="issues"
            name="issues"
          />
          <br/>
          <Button type="submit" variant="primary" block className="rounded">
            Save Changes
          </Button>

          <LinkContainer to="/projects">
            <Button variant="light" block className="rounded">
              <u>Cancel</u>
            </Button>
          </LinkContainer>
        </Form>
      </FormContainer>
    </FormikProvider>);
};
export default CreateProgressUpdate;