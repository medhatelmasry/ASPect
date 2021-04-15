import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./Views/Home";
import { Dashboard } from "./Views/Dashboard";
import Login from "./Views/Login";
import Signup from "./Views/Signup";
import ProjectList from "./Views/Projects";
import ProjectStatus from "./Views/ProjectStatus";
import PeerEvaluation from "./Views/PeerEvaluation";
import CreateProject from "./Views/CreateProject";
import EditStudentInfo from "./Views/EditStudentInfo";
import ForgotPassword from "./Views/ForgotPassword";
import "./custom.css";
import PreviousProgressUpdates from "./Views/PreviousProgressUpdates";
import CreateProgressUpdate from "./Views/CreateProgressUpdate";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route
          exact
          path="/dashboard"
          component={(studentId) => {
            studentId = localStorage.getItem("id");
            return <Dashboard studentId={studentId} />;
          }}
        />
        <Route exact path="/login" component={Login} />
        <Route exact path="/signup" component={Signup} />
        <Route exact path="/forgot-password" component={ForgotPassword} />
        <Route exact path="/projects" component={ProjectList} />
        <Route exact path="/projectstatus/:projectId" component={ProjectStatus} />
        <Route exact path="/create-project" component={CreateProject} />
        <Route
          exact
          path="/edit-student"
          component={(studentId) => {
            studentId = localStorage.getItem("id");
            return <EditStudentInfo studentId={studentId} />;
          }}
        />
        <Route exact path="/peer-evaluation" component={PeerEvaluation} />
        <Route exact path="/previous-progress-updates/:projectId" component={PreviousProgressUpdates} />
        <Route exact path="/create-progress-update/:projectId" component={CreateProgressUpdate} />
      </Layout>
    );
  }
}
