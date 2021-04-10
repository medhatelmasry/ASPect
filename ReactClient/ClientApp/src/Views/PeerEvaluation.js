import React from "react";
import { useHistory } from "react-router";

const PeerEvaluation = () => {
  const authenticated =
    localStorage.getItem("id") &&
    localStorage.getItem("token") &&
    localStorage.getItem("expiration")
      ? true
      : false;

  const history = useHistory();

  if (authenticated) {
    console.log("logged in");
  } else {
    console.log("not logged in");
    history.push("/login");
  }
  return <div>PeerEvaluation View</div>;
};

export default PeerEvaluation;
