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

  useEffect(() => {
    const getData = async () => {
      const { data } = await axios.get(
        `https://localhost:5001/api/Assignment/`
      );
      setAssignments(data);
    };
    getData();
  }, []);

  const renderAssignments = () => {
    return assignments.map((a, index) => (
      <tr key={index}>
        <td>{a.courseId}</td>
        <td>{a.description}</td>
        <td>{a.dateCreated}</td>
        <td>{a.dueDate}</td>
      </tr>
    ));
  };

  return (
    <Container>
      <h3>Dashboard</h3>

      <p className="mt-4 ml-2">
        Hello, <strong>{localStorage.getItem("name")}.</strong>
      </p>
      <p className="mt-4 ml-2">
        Your email address: <em>{localStorage.getItem("email")}.</em>
      </p>

      <LinkContainer to="/project-status">
        <Button className="my-2 mx-2">View Project Status</Button>
      </LinkContainer>

      <LinkContainer to="/create-project">
        <Button className="my-2 mx-2">Create Project</Button>
      </LinkContainer>

      <LinkContainer to="/edit-student">
        <Button className="my-2 mx-2">Edit Student Info</Button>
      </LinkContainer>

      <LinkContainer to="/peer-evaluation">
        <Button className="my-2 mx-2">Peer Evaluation</Button>
      </LinkContainer>

      <h4 className="mt-4">List of Assignments</h4>
      <Table striped bordered hover className="mt-4">
        <thead>
          <tr>
            <th>Course ID</th>
            <th>Description</th>
            <th>Assigned At</th>
            <th>Due By</th>
          </tr>
        </thead>
        <tbody>{renderAssignments()}</tbody>
      </Table>
    </Container>
  );
};
export default Dashboard;
