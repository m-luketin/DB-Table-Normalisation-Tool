import React from "react";
import AttributeSelector from "./AttributeSelector";

const Key = props => {
  return (
    <div className="Key">
      <AttributeSelector
        index={props.index}
        value={props.value}
        availableAttributes={props.availableAttributes}
        handleAdd={props.handleAdd}
        handleAddByEnter={props.handleAddByEnter}
        handleRemove={props.handleRemove}
      />
    </div>
  );
};

export default Key;
