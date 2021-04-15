import React, { useEffect, useState } from "react";
import axios from "axios";
import { Container, Table } from "react-bootstrap";
import { useHistory } from "react-router";
import { config } from "../util/config";

const Projects = (props) => {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    getData();
  }, []);

  const getData = async () => {
    const { data } = await axios.get(
      `https://localhost:5001/api/Project/`,
      config
    );
    setProjects(data);
  };

  const authenticated =
    localStorage.getItem("id") &&
    localStorage.getItem("token") &&
    localStorage.getItem("expiration")
      ? true
      : false;

  const history = useHistory();

  if (authenticated) {
    // console.log("logged in");
  } else {
    console.log("not logged in");
    history.push("/login");
  }
  const renderProjects = () => {
    return (
      <div>
        {projects.map((p, index) => (
          <div
            key={index}
            style={{
              border: "2px solid rgba(0, 0, 150, 0.4)",
              margin: "32px 0",
              padding: "10px",
              borderRadius: "10px",
            }}
          >
            <h4>App Name</h4>
            <h6>{p.appName}</h6>
            <h4>App Description</h4>
            <h6>{p.description}</h6>
            <h4>Project ID</h4>
            <h6>{p.projectId}</h6>
            <h4>Team Name</h4>
            <h6>{p.teamName}</h6>
            <h4>Students</h4>
            <Table striped bordered hover className="mt-4">
              <thead>
                <tr>
                  <th>Name</th>
                  <th>Email</th>
                </tr>
              </thead>
              <tbody>
                {p.memberships.map((e, index) => (
                  <tr key={index}>
                    <td>{e.student.firstName + " " + e.student.lastName}</td>
                    <td>{e.student.email}</td>
                  </tr>
                ))}
              </tbody>
            </Table>
          </div>
        ))}
      </div>
    );
  };
  return (
    <Container>
      <h1>Projects</h1>
      {renderProjects()}
    </Container>
  );
};

export default Projects;
