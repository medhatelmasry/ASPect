import React from "react";
import { Container, Button, Table } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";

const ProjectStatus = () => {
  return (
    <Container>
      <h3>Project Status</h3>
      <div className="mt-3">
        <p>Project Name: sample project</p>
        <p>Project Category: sample project category</p>
      </div>

      <Table striped bordered hover className="mt-4">
        <thead>
          <tr>
            <th>#</th>
            <th>Task</th>
            <th>Created Date</th>
            <th>Due Date</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>1</td>
            <td>Task A</td>
            <td>2021-01-01</td>
            <td>2021-01-11</td>
          </tr>
          <tr>
            <td>2</td>
            <td>Task B</td>
            <td>2021-01-06</td>
            <td>2021-02-01</td>
          </tr>
          <tr>
            <td>3</td>
            <td>Task C</td>
            <td>2021-01-22</td>
            <td>2021-02-15</td>
          </tr>
        </tbody>
      </Table>
    </Container>
  );
};

export default ProjectStatus;
