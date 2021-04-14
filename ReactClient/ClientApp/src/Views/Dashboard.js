import axios from "axios";
import React, { useState, useEffect } from "react";
import { Container, Button, Table } from "react-bootstrap";
import { useHistory } from "react-router";
import { LinkContainer } from "react-router-bootstrap";

export const Dashboard = (props) => {
  const [assignments, setAssignments] = useState([]);
  const authenticated =
    localStorage.getItem("id") &&
    localStorage.getItem("token") &&
    localStorage.getItem("expiration")
      ? true
      : false;

  const [userInfo, setUserInfo] = useState({
    firstName: "",
    lastName: "",
    userName: "",
  });

  const history = useHistory();

  if (authenticated) {
    console.log("logged in");
  } else {
    console.log("not logged in");
    history.push("/login");
  }

  const config = {
    headers: {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
    },
  };
  
  const getData = async () => {
    console.log(props);
        const { data } = await axios.get(`https://localhost:5001/api/Assignment/`);
        setAssignments(data);
    
  }

  useEffect(() => {
    getData()
  }, []);

  const { firstName, lastName, userName } = userInfo;
  const renderAssignments = () => {
    return assignments.map((a) => (
          <tr>
            <td>{a.courseId}</td>
            <td>{a.description}</td>
            <td>{a.dateCreated}</td>
            <td>{a.dueDate}</td>
            </tr>
        ),);
      
  }
  return (
    <Container>
      <h3>Dashboard</h3>
      
      <p className="mt-4 ml-2">
        Hello, <strong>{localStorage.getItem("name")}.</strong>
      </p>
      <p className="mt-4 ml-2">
        Your email address: <em>{localStorage.getItem("email")}.</em>
      </p>

      <h4>List of Assignments</h4>
      <Table striped bordered hover className="mt-4">
        <thead>
          <tr>
            <th>Course ID</th>
            <th>Description</th>
            <th>Assigned At</th>
            <th>Due By</th>
          </tr>
        </thead>
        <tbody>
        {renderAssignments()}

        </tbody>
      </Table>
    </Container>
  )
};export default Dashboard;
