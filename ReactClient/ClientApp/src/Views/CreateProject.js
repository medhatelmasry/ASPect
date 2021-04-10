import React from "react";
import CourseList from "../components/CourseList";

const CreateProject = () => {
  return (
    <>
      <h3>Create Project</h3>
      <div className="panel panel-default mt-4">
        <form>
          <div className="form-group">
            <label>Course Name:</label>
            <select className="form-control">
              <CourseList />
            </select>
          </div>

          <div className="form-group">
            <label>Project Category:</label>
            <select className="form-control"></select>
          </div>

          <div className="form-group">
            <label>Members:</label>
            <select className="form-control"></select>
          </div>
        </form>
      </div>
    </>
  );
};

export default CreateProject;
