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
  Peer: Yup.string()
    .required("Must choose who to review"),
  rating: Yup.number()
    .required("Rating is required")
    .min(0)
    .max(10),
  comments: Yup.string(),
});

const config = {
  headers: {
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*",
    "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
  },
};

const PeerEvaluation = (props) => {
  const [students, setStudents] = useState([]);
  const [projects, setProjects] = useState([]);
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
let studentIdList = [];
let projectIdList = [];
let targetIdList = [];
useEffect(() => {
  
    const getPeers = async () => {
    const result = await axios.get(
      "https://localhost:5001/api/Membership",
      config
    );
    const membershipList = result.data;
    membershipList.forEach((membership) => {
      if(membership.id === localStorage.getItem("id")){
        projectIdList.push(membership.projectId);
      } else {
        studentIdList.push(membership);
      }
    });
    studentIdList.forEach((student) => {
      projectIdList.forEach((project) => {
        if(student.projectId === project){
          targetIdList.push(student);
        }
      });
    });
    console.log(targetIdList);
    setStudents(studentIdList);
  }
  getPeers();
}, []);

  const [error, setError] = useState("");
  const [showAlert, setShowAlert] = useState(false);
  const formik = useFormik({
    initialValues: {
      UserBeingEvaluatedId: "",
      ProjectId:0,
      UserEvaluatingId: "",
      rating: 0,
      comments: "",
      date: "",
    },
    onSubmit: async (values) => {
      values.UserBeingEvaluatedId = values.Peer.substring(0, 36);
      values.ProjectId = values.Peer.substring(36);
      values.date = new Date().toLocaleString();
      values.UserEvaluatingId = localStorage.getItem("id");
      console.log(values);
      try {
        await axios.post(
          `https://localhost:5001/api/PeerEvaluation`,
          values,
          config
        );
        history.push("/dashboard");
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
          
          <Field as="select" id="Peer" name="Peer">
          <br/>
          <option>Select a peer</option>
            {
              
              students.map((index) => {
                
                return <option key={index} value={index.id + index.projectId}>{index.student.firstName} {index.student.lastName} Project: {index.projectId}
                </option>
            }
            )}
          </Field>
          <br/>
          <label htmlFor="rating">Rating 0-10</label>
          <br/>
          <Field
            id="rating"
            name="rating"
            type="number"
          />
          <br/>
          <label htmlFor="comments">Comments </label>
          <br/>
          <Field
            as="textarea"
            id="comments"
            name="comments"
          />
          <br/>

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
export default PeerEvaluation;