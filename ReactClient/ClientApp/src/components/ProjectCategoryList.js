import React, { useState, useEffect } from "react";
import axios from "axios";
import { config } from "../util/config";

const ProjectCategoryList = () => {
  const [ProjectCategoryLists, setProjectCategoryLists] = useState([]);

  useEffect(() => {
    const getProjectCategory = async () => {
      try {
        const { data } = await axios.get(
          `https://localhost:5001/api/ProjectCategories`,
          config
        );
        setProjectCategoryLists(data);
      } catch (error) {
        console.log(error);
      }
    };
    getProjectCategory();
  }, []);

  return ProjectCategoryLists.map((ProjectCategoryList) => {
    console.log(ProjectCategoryList);
    return (
      <option
        key={ProjectCategoryList.courseID}
        value={ProjectCategoryList.courseID}
      >
        {ProjectCategoryList.courseTitle}
      </option>
    );
  });
};

export default ProjectCategoryList;
