import React from "react";

const Attributes = props => {
  return (
    <div>
      <h1>Attributes in table</h1>
      <div>Separate attributes using a comma (,)</div>
      <textarea onChange={props.handleChange} value={props.attributes}></textarea>
    </div>
  );
};

export default Attributes;
