import React from "react";

const InputField = props => {
  return (
    <div className="InputFieldContent">
      <h1>{props.heading}</h1>
      <div className="InputFieldDescription">{props.description}</div>
      <textarea 
        spellCheck="false"
        className="FieldInput"
        onChange={props.handleChange}
        value={props.value}
      />
    </div>
  );
};

export default InputField;
