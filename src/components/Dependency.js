import React from "react";
import AttributeSelector from "./AttributeSelector";

const Dependency = props => {
  return (
    <div className="FunctionalDependency">
      <AttributeSelector
        value={props.dependencyLeft}
        availableAttributes={props.availableAttributes}
        handleAdd={props.handleAddLeft}
        handleRemove={props.handleRemoveLeft}
      />

      <div> --> </div>

      <AttributeSelector
        value={props.dependencyRight}
        availableAttributes={props.availableAttributes}
        handleAdd={props.handleAddRight}
        handleRemove={props.handleRemoveRight}
      />
    </div>
  );
};

export default Dependency;
