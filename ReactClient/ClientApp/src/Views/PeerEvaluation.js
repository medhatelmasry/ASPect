import React from "react";
import { useHistory } from "react-router";
import * as Yup from "yup";

const schema = Yup.object({
  targetId: Yup.string()
    .required("Must choose who to review"),
  rating: Yup.int()
    .required("Rating is required"),
  comments: Yup.string(),
  confirmPassword: Yup.string(),
});

const config = {
  headers: {
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*",
    "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
  },
};

const PeerEvaluation = () => {
  const [error, setError] = useState("");
  const [showAlert, setShowAlert] = useState(false);
  const history = useHistory();

  const formik = useFormik({
    initialValues: {
      PeerEvaluationId: localStorage.getItem("id"),
      targetId: 0,
      rating: 0,
      comments: "",
      date: "",
    },
    onSubmit: async (values) => {
      values.userName = values.email;
      values.firstname =
        values.firstname.charAt(0).toUpperCase() + values.firstname.slice(1);
      values.lastname =
        values.lastname.charAt(0).toUpperCase() + values.lastname.slice(1);
      values.normalizedUserName = values.email.toUpperCase();
      values.normalizedEmail = values.email.toUpperCase();
      const passwordHash = await bcrypt.hash(values.password, 10);
      values.passwordHash = passwordHash;
      console.log(values);

      const result = await axios.get(
        "https://openaspect.azurewebsites.net/api/Student",
        config
      );
      const studentList = result.data;
      let studentUserNameList = [];

      studentList.forEach((student) => {
        studentUserNameList.push(student.userName);
      });

      if (studentUserNameList.includes(values.userName)) {
        setError("Email is already in use");
        setShowAlert(true);
        history.push("/signup");
      } else {
        try {
          await axios.post(
            "https://openaspect.azurewebsites.net/api/Auth/register",
            values,
            config
          );
          history.push("/dashboard");
          console.log("created a student account");
        } catch (error) {
          console.log(error);
        }
      }
    },
    validationSchema: schema,
  });
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

  
  
  return (
    <>
    <div>PeerEvaluation View</div>
    <form>
      <p>Enter your name:</p>
      <input
        type="text"/>
        <textarea value={this.state.value} onchange={this.handleChange}/>
    </form>
  </>);
};
// public int ProjectId { get; set; }
//         //User that is doing the evaluation
//         public string UserEvaluatingId { get; set; }
//         //User that is receiving the evaluation
//         public string UserBeingEvaluatedId { get; set; }
//         //Comments from the student that is doing the evaluation
//         public string Comments { get; set; }
//         //A rating from 0 to 10(inclusive) on how the student is doing
//         [Range(0,10)]
//         public int Rating { get; set; }
//         //Date the evaluation was done
//         public DateTime Date { get; set; }


//         [ForeignKey("UserEvaluatingId")]
//         public ApplicationUser UserEvaluating { get; set; }

//         [ForeignKey("UserBeingEvaluatedId")]
//         public ApplicationUser UserBeingEvaluated { get; set; }

//         [ForeignKey("ProjectId")]
//         public Project Project { get; set; }
export default PeerEvaluation;
