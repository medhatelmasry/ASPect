import React, { useEffect, useState } from "react";
import axios from "axios";
import { Container, Table, Button} from "react-bootstrap";
import { useHistory, useParams } from "react-router";

const RoleList = (props) => {
  const [memberships, setMemberships] = useState([]);
  const [role, setRole] = useState([]);
  const [project, setProject] = useState([]);
  useEffect(() => {
    getData()
  }, [])
  const config = {
    headers: {
      "Content-Type": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
    },
  };
  const getData = async () => {
    const { data } = await axios.get(`https://localhost:5001/api/Project/${props.match.params.projectId}`,
      config
    );
    let tempMemberships = [];
    let tempRole = {};
    const isPM = false;
    data.memberships.forEach((membership) => {
      console.log(membership.student.id + " " +  localStorage.getItem("id"));
      if(membership.student.id === localStorage.getItem("id")){
        
        tempRole = membership
      } else {
        tempMemberships.push(membership);
      }
    });
    setRole(tempRole);
    setProject(data);
    setMemberships(tempMemberships);
  }

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

  const gotoAddMembership = (membership) => {
    localStorage.setItem("memberships", project.memberships)
    history.push("/project-member-add/" + props.match.params.projectId);
  }

  // const gotoEditMembership = (membership) => {
  //   localStorage.setItem("memberships", project.memberships)
  //   history.push("/project-member-edit/" + membership.id);
  // }

  const deleteMember = (membership) => {
    axios.delete(`https://localhost:5001/api/Membership/${membership.id}/${props.match.params.projectId}`,
      config
    ).then(res => {
      window.location.reload(false);
    })
  }

  return (
    <Container>
      <h1> Project Members</h1>
      <div style={{float: 'left', width: '75%'}}>
        <br/>
        <h3>{role.projectRole}</h3>
        <br/>
        <h3>{memberships.length + 1}</h3>
        <h6>members</h6>
      </div>
        
      <div style={{float: 'right', width: '25%'}}>
        <Button className="my-2 mx-2" onClick={() => gotoAddMembership()}>Add Member</Button>

      </div>
      
      <br></br>
      <h1>Other Members</h1>
      <Table striped bordered hover className="mt-4">
        <thead>
          <tr>
            <th>Name</th>
            <th>Role</th>
            {role.projectRole === "Project Manager" && 
                <th></th>
              }
              {/* {role.projectRole === "Project Manager" && 
                <th></th>
              } */}
            
          </tr>
        </thead>
        <tbody>
          {memberships.map((m) => (
            <tr>
              <td>{m.student.firstName + " " + m.student.lastName}</td>
              <td>{m.projectRole}</td>
              {/* {role.projectRole === "Project Manager" && 
                <td><Button className="my-2 mx-2" onClick={() => gotoEditMembership(m)}>Edit Role</Button></td>
              } */}
              {role.projectRole === "Project Manager" && 
                <td><Button className="my-2 mx-2" onClick={() => deleteMember(m)}>Delete Role</Button></td>
              }
              
            </tr>
          ))}
        </tbody>
      </Table>
    </Container>
  )
};

export default RoleList;
