import React, { useState } from "react";
import { useField, Field } from "formik";
import "../../index.css";

const TextInputLiveFeedback = ({ label, helpText, ...props }) => {
  const [field, meta] = useField(props);
  const [didFocus, setDidFocus] = useState(false);
  const handleFocus = () => setDidFocus(true);
  const showFeedback =
    (!!didFocus && field.value.trim().length > 2) || meta.touched;

  return (
    <div
      className={`${showFeedback ? (meta.error ? "invalid" : "valid") : ""}`}
    >
      <div className="d-flex align-items-center justify-content-between">
        <label htmlFor={props.id}>{label}</label>{" "}
        {showFeedback ? (
          <div
            id={`${props.id}-feedback`}
            aria-live="polite"
            className="feedback text-sm"
          >
            {meta.error ? meta.error : "✓"}
          </div>
        ) : null}
      </div>
      <Field
        {...props}
        {...field}
        name={props.name}
        aria-describedby={`${props.id}-feedback ${props.id}-help`}
        onFocus={handleFocus}
        className={`w-100 border rounded mb-3 border-${
          showFeedback ? (meta.error ? "danger" : "success") : ""
        }`}
        style={{ fontSize: "18px" }}
      />
    </div>
  );
};

export default TextInputLiveFeedback;
