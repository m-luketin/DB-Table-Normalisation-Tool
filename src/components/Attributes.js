import React from "react";

const Attributes = props => {
  return (
    <div>
      <h1>Attributes in table</h1>
      <span>Separate attributes using a comma (,)</span>
      <textarea onChange={props.handleChange} value={props.attributes}></textarea>
    </div>
  );
};

export default Attributes;
