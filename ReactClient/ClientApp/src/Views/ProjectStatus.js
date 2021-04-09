import React from "react";
import { Container, Button, Table } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";

const ProjectStatus = () => {
  return (
    <Container>
      <h3>Project Status</h3>
      <p>Project Name: sample project</p>
      {/* { "dateCreated": "2020-01-01", "dueDate": "2019-02-05", "requirement": "Complete Wireframes", "assignmentId": 1 }", */}
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Requirement</th>
            <th>Created Date</th>
            <th>Due Date</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>1</td>
            <td>Requirement A</td>
            <td>2021-01-01</td>
            <td>2021-01-11</td>
          </tr>
          <tr>
            <td>2</td>
            <td>Requirement B</td>
            <td>2021-01-06</td>
            <td>2021-02-01</td>
          </tr>
          <tr>
            <td>3</td>
            <td>Requirement C</td>
            <td>2021-01-22</td>
            <td>2021-02-15</td>
          </tr>
        </tbody>
      </Table>
    </Container>
  );
};

export default ProjectStatus;
