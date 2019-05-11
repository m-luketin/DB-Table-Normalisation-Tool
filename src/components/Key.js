import React from "react";
import AttributeSelector from "./AttributeSelector";

const Key = props => {
  return (
    <div className="Key">
      <AttributeSelector
        keyValue={props.keyValue}
        availableAttributes={props.availableAttributes}
        handleAdd={props.handleAdd}
        handleRemove={props.handleRemove}
      />
    </div>
  );
};

export default Key;
