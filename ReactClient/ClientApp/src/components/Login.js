import React, { useState, useEffect } from "react";
import * as Yup from "yup";
import { useFormik, FormikProvider, Form } from "formik";
import { Button, Image, Row, Alert } from "react-bootstrap";
import { Link, useHistory } from "react-router-dom";
import FormContainer from "../components/common/FormContainer";
import TextInputLiveFeedback from "../components/common/TextInputLiveFeedback";
import { emailRegex } from "../util/regex";

const schema = Yup.object({
  email: Yup.string()
    .required("Email is required")
    .matches(emailRegex, "Invalid"),
  password: Yup.string().required("Password is required"),
});

const Login = () => {
  const [error, setError] = useState("");
  const [showAlert, setShowAlert] = useState(false);

  const formik = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    onSubmit: async (values) => {
      console.log(values);
    },
    validationSchema: schema,
  });

  return (
    <>
      <FormikProvider value={formik}>
        <FormContainer>
          <Row className="text-center">
            <h1 className="mb-4 mx-auto">Login</h1>
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

            <Button type="submit" variant="primary" block className="rounded">
              Login
            </Button>

            <Row className="text-center">
              <Link
                className="ml-3 mt-3 text-left text-secondary"
                to="/forgot-password"
              >
                <u>Forgot Password</u>
              </Link>
            </Row>
          </Form>
        </FormContainer>
      </FormikProvider>
    </>
  );
};

export default Login;
