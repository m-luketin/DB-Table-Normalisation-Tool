import React from "react";

const Attributes = props => {
  return (
    <div className="AttributesContent">
      <h1>Attributes in table</h1>
      <div className="Description">Separate attributes using a comma ( , )</div>
      <textarea 
        spellCheck="false"
        className="AttributeInput"
        onChange={props.handleChange}
        value={props.attributes}
      />
    </div>
  );
};

export default Attributes;
