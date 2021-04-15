import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import * as Yup from "yup";
import { LinkContainer } from "react-router-bootstrap";
import { Field, useFormik, FormikProvider, Form } from "formik";
import { Button, Alert, Row } from "react-bootstrap";
import FormContainer from "../components/FormContainer";
import TextInputLiveFeedback from "../components/TextInputLiveFeedback";
import { nameRegex, emailRegex, passwordRegex } from "../util/regex";
import bcrypt from "bcryptjs";
import axios from "axios";

const schema = Yup.object({
  id: Yup.string()
    .required("Must choose who to review"),
  projectRole: Yup.string(),
});

const config = {
  headers: {
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*",
    "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
  },
};

const ProjectMemberAdd = (props) => {
  const [students, setStudents] = useState([]);
  const authenticated =
  localStorage.getItem("id") &&
  localStorage.getItem("token") &&
  localStorage.getItem("expiration")
    ? true
    : false;

const history = useHistory();

if (authenticated) {
  //console.log("logged in");
} else {
  //console.log("not logged in");
  //history.push("/login");
}
let studentList = [];
useEffect(() => {
  
    const getPeers = async () => {
    const { data } = await axios.get(
      "https://localhost:5001/api/Student",
      config
    );
    const studentList = data;
    const temp = await axios.get(
      "https://localhost:5001/api/Project/" + props.match.params.projectId,
      config
    );
    const memberships = temp.data.memberships;
    console.log(memberships);
    const validStudents = [];
    studentList.forEach((student) => {
      let valid = true;
      memberships.forEach((membership) => {
        if (membership.student.id === student.id) {
          valid = false;
        }
      })
      if (valid) {
        validStudents.push(student);
      }
    });
    
    setStudents(validStudents);
  }
  getPeers();
}, []);

  const [error, setError] = useState("");
  const [showAlert, setShowAlert] = useState(false);
  const formik = useFormik({
    initialValues: {
      projectId: props.match.params.projectId,
      id: "",
      projectRole: "",
    },
    onSubmit: async (values) => {
      console.log(values);

      try {
        await axios.post(
          `https://localhost:5001/api/Membership`,
          values,
          config
        );
        history.push("/project-members/" + props.match.params.projectId);
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
          <h1 className="mb-4 mx-auto">Peer Evaluation</h1>
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
          
          <Field as="select" id="id" name="id">
            {
              students.map((index) => {
                
                return <option value={index.id}>{index.firstName + " " + index.lastName}
                </option>
            }
            )}
          </Field>
          <TextInputLiveFeedback
            label="Project Role"
            id="projectRole"
            name="projectRole"
            type="projectRole"
          />

          <Button type="submit" variant="primary" block className="rounded">
            Save Changes
          </Button>

          <LinkContainer to="/dashboard">
            <Button variant="light" block className="rounded">
              <u>Cancel</u>
            </Button>
          </LinkContainer>
        </Form>
      </FormContainer>
    </FormikProvider>);
};
// public int ProjectId { get; set; }
//         //User that is doing the evaluation
//         public string UserEvaluatingId { get; set; }
//         //User that is receiving the evaluation
//         public string UserBeingEvaluatedId { get; set; }
//         //Comments from the student that is doing the evaluation
//         public string Comments { get; set; }
//         //A rating from 0 to 10(inclusive) on how the student is doing
//         [Range(0,10)]
//         public int Rating { get; set; }
//         //Date the evaluation was done
//         public DateTime Date { get; set; }


//         [ForeignKey("UserEvaluatingId")]
//         public ApplicationUser UserEvaluating { get; set; }

//         [ForeignKey("UserBeingEvaluatedId")]
//         public ApplicationUser UserBeingEvaluated { get; set; }

//         [ForeignKey("ProjectId")]
//         public Project Project { get; set; }
export default ProjectMemberAdd;