import React, { useEffect, useState } from "react";
import axios from "axios";
import { Container, Table } from "react-bootstrap";
import { useHistory } from "react-router";
const Projects = (props) => {
const [projects, setProjects] = useState([]);

useEffect(() => {
  getData()
}, [])
const config = {
  headers: {
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*",
    "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
  },
};
const getData = async () => {
  const { data } = await axios.get(`https://localhost:5001/api/Project/`,
  config
  );
  setProjects(data);
}


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
  const renderProjects = () => {
    return (
      <div>
        {projects.map((e) => (
          <Table striped bordered hover className="mt-4">
            <thead>
              <tr>
                <th>#</th>
                <th>Team Name</th>
                <th>App Name</th>
                <th>App Description</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>{e.projectId}</td>
                <td>{e.teamName}</td>
                <td>{e.appName}</td>
                <td>{e.description}</td>
              </tr>
            </tbody>
          </Table>))}
      </div>
    );
  }
  return (
    <Container>
      <h3>Projects</h3>
      {renderProjects()}
    </Container>
  )
};

export default Projects;
