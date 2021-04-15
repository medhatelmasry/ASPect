import React, { useState, useEffect } from "react";
import axios from "axios";
import { config } from "../util/config";

const OfferingList = () => {
  const [OfferingLists, setOfferingLists] = useState([]);

  useEffect(() => {
    const getOfferings = async () => {
      try {
        const { data } = await axios.get(`/api/Offering`, config);
        console.log(data);
        // data.map((offering, index) => {
        //   console.log(offering.course);
        // });
        setOfferingLists(data);
      } catch (error) {
        console.log(error);
      }
    };
    getOfferings();
  }, []);

  return (
    <>
      {OfferingLists.map((OfferingList) => {
        // return console.log(OfferingList);
        return (
          <option key={OfferingList.offeringId} value={OfferingList.offeringId}>
            {OfferingList.semester} {OfferingList.term}
            {OfferingList.course.courseTitle}
          </option>
        );
      })}
    </>
  );
};

export default OfferingList;
