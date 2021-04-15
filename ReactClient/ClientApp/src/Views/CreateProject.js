import React, { useState, useEffect } from "react";
import { useHistory } from "react-router";
import { Container } from "react-bootstrap";
import CourseList from "../components/CourseList";
import ProjectCategoryList from "../components/ProjectCategoryList";
import { config } from "../util/config";
import axios from "axios";
import OfferingList from "../components/OfferingList";

const CreateProject = () => {
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

  const [courseID, setCourseID] = useState(1);
  const [aspNetUserId, setAspNetUserId] = useState("");
  const [instructorName, setInstructorName] = useState("");
  const [projectCategoryId, setProjectCategoryId] = useState(1);
  const [members, setMembers] = useState([]);
  const [teamName, setTeamName] = useState("");
  const [appName, setAppName] = useState("");
  const [description, setDescription] = useState("");

  useEffect(() => {
    const getInstructorNameByCourseID = async () => {
      const { instructorID } = (
        await axios.get(`/api/Courses/${courseID}`, config)
      ).data;
      const { firstName, lastName } = (
        await axios.get(`/api/Instructor/${instructorID}`, config)
      ).data;
      const tempFullName = `${firstName} ${lastName}`;
      setInstructorName(tempFullName);
    };

    getInstructorNameByCourseID();
  }, []);

  const createProject = async (event) => {
    event.preventDefault();
    const body = JSON.stringify({
      courseID,
      aspNetUserId,
      projectCategoryId,
      // members,
      teamName,
      appName,
      description,
    });

    console.log(body);

    try {
      await axios.post(`/api/Project`, body, config);
      history.push(`/dashboard`);
      console.log(`Project AppName: ${appName} was created`);
    } catch (error) {
      console.log(error);
    }
  };

  const cancelCreateProject = () => {
    history.push(`/dashboard`);
  };

  return (
    <>
      <h3>Create Project</h3>
      <Container>
        <div className="panel panel-default mt-4 w-50">
          <form>
            <div className="form-group">
              <label>Offering:</label>
              <select
                className="form-control"
                // value={courseID}
                // onChange={(event) => setCourseID(event.target.value)}
              >
                <OfferingList />
              </select>
            </div>

            <div className="form-group">
              <label>Course Name:</label>
              <select
                className="form-control"
                value={courseID}
                onChange={(event) => setCourseID(event.target.value)}
              >
                <CourseList />
              </select>
            </div>

            <div className="form-group">
              <input
                className="form-control"
                type="text"
                value={aspNetUserId}
                onChange={(event) => setAspNetUserId(event.target.value)}
                hidden
              />
            </div>

            <div className="form-group">
              <label>Instructor Name:</label>{" "}
              <input
                className="form-control"
                type="text"
                placeholder="Instructor Name"
                value={instructorName}
                onChange={(event) => setInstructorName(event.target.value)}
                disabled
              />
            </div>

            <div className="form-group">
              <label>Project Category:</label>
              <select
                className="form-control"
                value={projectCategoryId}
                onChange={(event) => setProjectCategoryId(event.target.value)}
              >
                <ProjectCategoryList />
              </select>
            </div>

            {/* <div className="form-group">
              <label>Team Members:</label>
              <select className="form-control"></select>
            </div> */}

            <div className="form-group">
              <label>Team Name:</label>
              <input
                className="form-control"
                type="text"
                placeholder="Team Name"
                value={teamName}
                onChange={(event) => setTeamName(event.target.value)}
                required
              />
            </div>

            <div className="form-group">
              <label>App Name:</label>
              <input
                className="form-control"
                type="text"
                placeholder="App Name"
                value={appName}
                onChange={(event) => setAppName(event.target.value)}
                required
              />
            </div>

            <div className="form-group">
              <label>Description:</label>
              <input
                className="form-control"
                type="text"
                placeholder="Description"
                value={description}
                onChange={(event) => setDescription(event.target.value)}
                required
              />
            </div>

            <button
              onClick={(event) => createProject(event)}
              className="btn btn-success mr-3"
            >
              Create
            </button>
            <button onClick={() => cancelCreateProject()} className="btn">
              Cancel
            </button>
          </form>
        </div>
      </Container>
    </>
  );
};

export default CreateProject;
