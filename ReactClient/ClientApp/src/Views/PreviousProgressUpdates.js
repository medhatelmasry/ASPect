import React, { useEffect, useState } from "react";
import axios from "axios";
import { Container, Table } from "react-bootstrap";
import { useHistory } from "react-router";
import { BrowserRouter as useParams } from "react-router-dom";

const PreviousProgressUpdates = (props) => {
  const [progressUpdates, setProgressUpdates] = useState([]);

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
  let id = props.match.params.projectId;
  console.log("ID:" + id);
  const getData = async () => {
    const { data } = await axios.get(`https://localhost:5001/api/Project/${props.match.params.projectId}`,
      config
    );
    let temp = data.progressUpdates;
    let progressUpdates = [];
    temp.forEach((update) => {
      if (update.complete) {
        progressUpdates.push(update);
      }
    });
    setProgressUpdates(progressUpdates);
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
  const renderProgress = () => {
    return (
      <div>
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
            {
              progressUpdates.map((p) => (
                <tr>
                  <td>{p.projectId}</td>
                  <td>{p.lastWeekActivity}</td>
                  <td>{p.nextWeekActivity}</td>
                  <td>{p.issues}</td>
                  <td>{p.date}</td>
                  <td></td>
                </tr>
              ))
            }
          </tbody>
        </Table>
      </div>
    );
  }
  return (
    <Container>
      <h1>Previous Progress Updates</h1>
      {renderProgress()}
    </Container>
  )
};

export default PreviousProgressUpdates;
