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
  targetId: Yup.string()
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
      peerEvaluationId: "",
      targetId: "",
      rating: 0,
      comments: "",
      date: "",
    },
    onSubmit: async (values) => {
      console.log("ah");
      values.date = new Date().toLocaleString();
      values.peerEvaluationId = localStorage.getItem("id");
      console.log("ah");
      console.log(values);
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
          {/* <TextInputLiveFeedback
            label="Email"
            id="email"
            name="email"
            type="email"
          /> */}
          
          <Field as="select" id="targetId" name="targetId">
            <option >"--FUCKING PICK SOMETHING--"</option>
            {
              students.map((index) => {
                
                return <option value={index.id}>{index.id}
                </option>
            }
            )}
          </Field>

          <Field
            label="Rating"
            id="rating"
            name="rating"
            type="number"
          />
          <TextInputLiveFeedback
            label="Comments"
            id="comments"
            name="comments"
            type="text"
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
export default PeerEvaluation;