import React from "react";
import Dependency from "./Dependency";
import { splitAttributes } from "./../utils";

const DependenciesDisplay = props => {
  const handleAttributeAddLeft = (event, index) => {
    props.handleAttributeAddLeft(event, index);
  };

  const handleAttributeAddRight = (event, index) => {
    props.handleAttributeAddRight(event, index);
  };

  const handleAttributeRemoveLeft = (event, index) => {
    props.handleAttributeRemoveLeft(event, index);
  };

  const handleAttributeRemoveRight = (event, index) => {
    props.handleAttributeRemoveRight(event, index);
  };

  return (
    <div>
      <h1>Functional dependencies</h1>
      <ul>
        {props.dependenciesLeft.map((dependency, index) => (
          <li key={index} className="DependencyElement">
            <Dependency
              availableAttributes={splitAttributes(props.attributes)}
              dependencyLeft={dependency}
              dependencyRight={props.dependenciesRight[index]}
              handleAddLeft={event => handleAttributeAddLeft(event, index)}
              handleAddRight={event => handleAttributeAddRight(event, index)}
              handleRemoveLeft={event =>
                handleAttributeRemoveLeft(event, index)
              }
              handleRemoveRight={event =>
                handleAttributeRemoveRight(event, index)
              }
            />
            <button
              className="Button"
              onClick={() => props.handleDependencyRemove(index)}
            >
              <svg height="40" width="40">
                <line className="SvgLine" x1="10" y1="20" x2="30" y2="20" />
              </svg>
            </button>
          </li>
        ))}
      </ul>
      <button className="Button" onClick={props.handleDependencyAdd}>
        <svg height="40" width="40">
          <line className="SvgLine" x1="10" y1="20" x2="30" y2="20" />
          <line className="SvgLine" x1="20" y1="10" x2="20" y2="30" />
        </svg>
      </button>
    </div>
  );
};

export default DependenciesDisplay;
