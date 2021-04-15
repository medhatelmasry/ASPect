import React, { useEffect, useState } from "react";
import axios from "axios";
import { Container, Table } from "react-bootstrap";
import { useHistory, useParams } from "react-router";

const ProjectStatus = (props) => {
  const [progressUpdates, setProjectUpdates] = useState([]);
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
    const { data } = await axios.get(`https://localhost:5001/api/Project/${props.match.params.projectId}`,
      config
    );
    let temp = data.progressUpdates;
    let progressUpdates = [];
    temp.forEach((update) => {
      if(!update.complete){
        progressUpdates.push(update);
      } 
    });
    setProjectUpdates(progressUpdates);
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

  return (
    <Container>
      <h1>Tasks</h1>
      <Table striped bordered hover className="mt-4">
        <thead>
          <tr>
            <th>Description</th>
            <th>Date</th>
          </tr>
        </thead>
        <tbody>
          {progressUpdates.map((p) => (
            <tr>
              <td>{p.issues}</td>
              <td>{p.date}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </Container>
  )
};

export default ProjectStatus;
