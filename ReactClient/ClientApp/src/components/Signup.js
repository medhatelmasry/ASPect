import React, { useState } from "react";
import * as Yup from "yup";
import { useHistory } from "react-router-dom";
import { useFormik, FormikProvider, Form } from "formik";
import { Button, Alert, Row } from "react-bootstrap";
import FormContainer from "./common/FormContainer";
import TextInputLiveFeedback from "./common/TextInputLiveFeedback";
import { emailRegex, passwordRegex } from "../util/regex";

const schema = Yup.object({
  email: Yup.string()
    .required("Email is required")
    .matches(emailRegex, "Invalid"),
  password: Yup.string()
    .min(8, "Must be at least 8 characters")
    .max(20, "Must be less than 20 characters")
    .required("Password is required")
    .matches(passwordRegex, "Invalid"),
  confirmPassword: Yup.string()
    .min(8, "Must be at least 8 characters")
    .max(20, "Must be less than 20 characters")
    .required("Confirm password is required")
    .matches(passwordRegex, "Invalid")
    .when("password", {
      is: (val) => (val && val.length > 0 ? true : false),
      then: Yup.string().oneOf([Yup.ref("password")], "Passwords do not match"),
    }),
});

const Signup = ({ onSubmit }) => {
  const [error, setError] = useState("");
  const [showAlert, setShowAlert] = useState(false);
  const history = useHistory();

  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
      confirmPassword: "",
    },
    onSubmit: async (values) => {
      console.log(values);

      // if (val.length === 0) {
      history.push("/dashboard");
      // } else {
      //   setError("Email is already in use");
      //   setShowAlert(true);
      //   console.log(error);
      //   history.push("/signup");
      // }
    },
    validationSchema: schema,
  });

  return (
    <FormikProvider value={formik}>
      <FormContainer>
        <Row className="text-center">
          <h1 className="mb-4 mx-auto">Sign up for a Student account</h1>
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
          <TextInputLiveFeedback
            label="Email"
            id="email"
            name="email"
            type="email"
          />

          <TextInputLiveFeedback
            label="Password"
            id="password"
            name="password"
            type="password"
          />

          <TextInputLiveFeedback
            label="Confirm Password"
            id="confirmPassword"
            name="confirmPassword"
            type="password"
          />

          <Button
            type="submit"
            variant="primary"
            block
            className="rounded"
            onClick={onSubmit}
          >
            Create an account
          </Button>
        </Form>
      </FormContainer>
    </FormikProvider>
  );
};
export default Signup;
