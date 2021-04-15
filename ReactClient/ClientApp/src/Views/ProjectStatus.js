import React, { useEffect, useState } from "react";
import axios from "axios";
import { Container, Table, Button } from "react-bootstrap";
import { useHistory, useParams } from "react-router";

const ProjectStatus = (props) => {
  const [progressUpdates, setProjectUpdates] = useState([]);
  useEffect(() => {
    getData();
  }, []);
  const config = {
    headers: {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
    },
  };
  const getData = async () => {
    const { data } = await axios.get(
      `https://localhost:5001/api/Project/${props.match.params.projectId}`,
      config
    );
    let temp = data.progressUpdates;
    let progressUpdates = [];
    temp.forEach((update) => {
      if (!update.complete) {
        progressUpdates.push(update);
      }
    });
    setProjectUpdates(progressUpdates);
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



  const markComplete = async (progressUpdate)=>{

    console.log(progressUpdate);
    const { result } = await axios.put(
      `https://localhost:5001/api/progressupdate/${progressUpdate.id}`,
      config
    );
    window.location.reload(false);
  } 


  const gotoCreateStatusPage = (projectId) => {
    history.push("/create-progress-update/" + projectId);
  }
  const gotoPreviousProgressPage = (projectId) => {
    history.push("/previous-progress-updates/" + projectId);
  }
  const gotoMemberPage = (projectId) => {
    history.push("/project-members/" + projectId);
  }
  return (
    <Container>
      <h1>Weekly Status</h1>
      <Button className="my-8 mx-8" onClick={() => gotoCreateStatusPage(props.match.params.projectId)}>Create New Status</Button>
      <Button className="my-8 mx-8" onClick={() => gotoPreviousProgressPage(props.match.params.projectId)}>View Previous Status Updates</Button>
      <Button className="my-8 mx-8" onClick={() => gotoMemberPage(props.match.params.projectId)}>View Team Members</Button>
      <Table striped bordered hover className="mt-4">
        <thead>
          <tr>
            <th>Project ID</th>
            <th>Last Weeks Activity</th>
            <th>Next Week Activity</th>
            <th>Issues</th>
            <th>Date</th>
            <th>Complete?</th>
          </tr>
        </thead>
        <tbody>
          {progressUpdates.map((p) => (
            <tr>
              <td>{p.projectId}</td>
              <td>{p.lastWeekActivity}</td>
              <td>{p.nextWeekActivity}</td>
              <td>{p.issues}</td>
              <td>{p.date}</td>
              <td><input type="checkbox" onClick={() => markComplete(p)}/></td>
            </tr>
          ))}
        </tbody>
      </Table>
    </Container>
  );
};

export default ProjectStatus;
