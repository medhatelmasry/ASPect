import React, { Component } from "react";
import { Container, Button } from "react-bootstrap";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <>
        <h3 className="text-center pt-3">Welcome to ASPECT Student Portal</h3>

        <div className="ml-5 mt-5">
          <p style={{ color: "red" }}>
            <strong>Authentication is not implemented yet.</strong>
          </p>
          <p>
            <strong>Home</strong> routing: /
          </p>
          <p>
            <strong>Dashboard</strong> routing: /dashboard
          </p>
          <p>
            <strong>Login</strong> routing: /login
          </p>
          <p>
            <strong>Signup</strong> routing: /signup
          </p>
          <p>
            <strong>ForgotPassword</strong> routing: /forgot-password
          </p>
          <p>
            <strong>ProjectStatus</strong> routing: /project-status
          </p>
          <p>
            <strong>CreateProject</strong> routing: /create-project
          </p>
          <p>
            <strong>EditStudentInfo</strong> routing: /edit-student
          </p>
          <p>
            <strong>PeerEvaluation</strong> routing: /peer-evaluation
          </p>
        </div>
      </>
    );
  }
}
