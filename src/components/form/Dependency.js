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
        outputTooltip="This is your functional dependency"
        tooltipId="DependencyTooltip"
      />

      <div className="DependencyArrow">
        <div className="Dot" />
        <div className="Dot" />
        <div className="Dot" />
        <svg
          className="Triangle"
          width="60px"
          height="80px"
          viewBox="0 -10 50 95"
        >
          <polyline
            fill="none"
            stroke="#9e9e9e"
            strokeWidth="10"
            strokeLinecap="round"
            strokeLinejoin="round"
            points="0.375,0.375 45.63,38.087 0.375,75.8"
          />
        </svg>
      </div>

      <AttributeSelector
        index={props.index}
        value={props.dependencyRight}
        availableAttributes={props.availableAttributes}
        handleAdd={props.handleAddRight}
        handleAddByEnter={props.handleAddByEnterRight}
        handleRemove={props.handleRemoveRight}
        outputTooltip="This is your functional dependency"
        tooltipId="DependencyTooltip"
      />
    </div>
  );
};

export default Dependency;
