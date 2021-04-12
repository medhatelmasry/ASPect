import React, { Component } from "react";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <>
        <h3 className="text-center pt-3">Welcome to ASPECT Student Portal</h3>

        <div className="ml-5 mt-5">
          <p>
            <strong>(public) Home</strong> routing: /
          </p>
          <p>
            <strong>(public) Login</strong> routing: /login
          </p>
          <p>
            <strong>(public) Signup</strong> routing: /signup
          </p>
          <p>
            <strong>(public) ForgotPassword</strong> routing: /forgot-password
          </p>
          <hr />
          <p>
            <strong>(private) Dashboard</strong> routing: /dashboard
          </p>
          <p>
            <strong>(private) ProjectStatus</strong> routing: /project-status
          </p>
          <p>
            <strong>(private) CreateProject</strong> routing: /create-project
          </p>
          <p>
            <strong>(private) EditStudentInfo</strong> routing: /edit-student
          </p>
          <p>
            <strong>(private) PeerEvaluation</strong> routing: /peer-evaluation
          </p>
        </div>
      </>
    );
  }
}
