import React from "react";
import AttributeSelector from "./AttributeSelector";

const Dependency = props => {
  return (
    <div className="FunctionalDependency">
      <AttributeSelector
        index={props.index}
        value={props.dependencyLeft}
        availableAttributes={props.availableAttributes}
        handleAdd={props.handleAddLeft}
        handleAddByEnter={props.handleAddByEnterLeft}
        handleRemove={props.handleRemoveLeft}
      />

      <div> --> </div>

      <AttributeSelector
        index={props.index}
        value={props.dependencyRight}
        availableAttributes={props.availableAttributes}
        handleAdd={props.handleAddRight}
        handleAddByEnter={props.handleAddByEnterRight}
        handleRemove={props.handleRemoveRight}
      />
    </div>
  );
};

export default Dependency;
