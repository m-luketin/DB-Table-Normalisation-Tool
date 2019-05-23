import React from "react";
import Dependency from "./Dependency";
import { splitAttributes } from "../../utils";

const DependenciesDisplay = props => {
  const handleAttributeAddFrom = (event, index) => {
    props.handleAttributeAddFrom(event, index);
  };

  const handleAttributeAddTo = (event, index) => {
    props.handleAttributeAddTo(event, index);
  };

  const handleAttributeRemoveFrom = (event, index) => {
    props.handleAttributeRemoveFrom(event, index);
  };

  const handleAttributeRemoveTo = (event, index) => {
    props.handleAttributeRemoveTo(event, index);
  };

  return (
    <div>
      <h1>Functional dependencies</h1>
      <div className="DependencyContent">
        <ul>
          {props.dependenciesFrom.map((dependency, index) => (
            <li key={index} className="DependencyElement">
              <Dependency
                index={index}
                availableAttributes={splitAttributes(props.attributes)}
                dependencyFrom={dependency}
                dependencyTo={props.dependenciesTo[index]}
                handleAddFrom={event => handleAttributeAddFrom(event, index)}
                handleAddTo={event => handleAttributeAddTo(event, index)}
                handleAddByEnterFrom={props.handleAttributeAddByEnterFrom}
                handleAddByEnterTo={props.handleAttributeAddByEnterTo}
                handleRemoveFrom={event =>
                  handleAttributeRemoveFrom(event, index)
                }
                handleRemoveTo={event =>
                  handleAttributeRemoveTo(event, index)
                }
              />
              <button
                className="Button ButtonRemove"
                onClick={() => props.handleDependencyRemove(index)}
              >
                <svg height="40" width="40">
                  <line className="SvgLine" x1="10" y1="20" x2="30" y2="20" />
                </svg>
              </button>
            </li>
          ))}
        </ul>
        <button className="Button ButtonAdd" onClick={props.handleDependencyAdd}>
          <svg height="40" width="40">
            <line className="SvgLine" x1="10" y1="20" x2="30" y2="20" />
            <line className="SvgLine" x1="20" y1="10" x2="20" y2="30" />
          </svg>
        </button>
      </div>
    </div>
  );
};

export default DependenciesDisplay;
