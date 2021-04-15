import React, { useState, useEffect } from "react";
import axios from "axios";
import { config } from "../util/config";

const CourseList = () => {
  const [CourseLists, setCourseLists] = useState([]);

  useEffect(() => {
    const getCourses = async () => {
      try {
        const { data } = await axios.get(`/api/Courses`, config);
        setCourseLists(data);
      } catch (error) {
        console.log(error);
      }
    };
    getCourses();
  }, []);

  return (
    <>
      {CourseLists.map((CourseList) => (
        <option key={CourseList.courseID} value={CourseList.courseID}>
          {CourseList.courseTitle}
        </option>
      ))}
    </>
  );
};

export default CourseList;
