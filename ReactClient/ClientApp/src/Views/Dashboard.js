import React from "react";
import { Container, Button } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";

export const Dashboard = () => {
  return (
    <Container>
      <h3>Dashboard</h3>
      <p>Hello, User.</p>

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
    </Container>
  );
};
