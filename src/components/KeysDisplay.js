import React from "react";
import Key from "./Key";
import {splitAttributes} from "./../utils";

const KeysDisplay = props => {
  const handleAttributeAdd = (event, index) => {
    props.handleAttributeAdd(event, index);
  };
  
  const handleAttributeRemove = (event, index) => {
    props.handleAttributeRemove(event, index);
  };
  
  const handleKeyRemove = index => {
    props.handleKeyRemove(index);
  };
  
  return (
    <div>
      <h1>Keys in table</h1>
      <ul>
        {props.keys.map((keyAttributes, index) => {
          return (
            <li key={index} className="KeyElement">
              <Key
                value={keyAttributes}
                availableAttributes={splitAttributes(props.attributes)}
                handleAdd={event => handleAttributeAdd(event, index)}
                handleRemove={event => handleAttributeRemove(event, index)}
              />
              <button onClick={() => handleKeyRemove(index)}>Remove</button>
            </li>
          );
        })}
      </ul>
      <button onClick={props.handleKeyAdd}>Add key</button>
    </div>
  );
};

export default KeysDisplay;
