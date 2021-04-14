import React, { useState, useEffect } from "react";
import axios from "axios";
import { config } from "../util/config";

const ProjectCategoryList = () => {
  const [ProjectCategoryLists, setProjectCategoryLists] = useState([]);

  useEffect(() => {
    const getProjectCategory = async () => {
      try {
        const { data } = await axios.get(`/api/ProjectCategories`, config);
        setProjectCategoryLists(data);
      } catch (error) {
        console.log(error);
      }
    };
    getProjectCategory();
  }, []);

  return ProjectCategoryLists.map((ProjectCategoryList) => {
    return (
      <option
        key={ProjectCategoryList.projectCategoryId}
        value={ProjectCategoryList.projectCategoryId}
      >
        {ProjectCategoryList.projectCategoryName}
      </option>
    );
  });
};

export default ProjectCategoryList;
