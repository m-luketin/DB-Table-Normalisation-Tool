import React from "react";
import Key from "./Key";

const KeysDisplay = props => {
  const handleAttributeAdd = (event, index) => {
    props.handleAttributeAdd(event, index);
  };
  
  const handleAttributeRemove = (event, index) => {
    props.handleAttributeRemove(event, index);
  };
  
  const handleRemoveKey = index => {
    props.handleKeyRemove(index);
  };
  
  const splitAttributes = string => {
    return string.replace(" ", "").split(",");
  };
  
  return (
    <div>
      <h1>Keys in table</h1>
      <span>Jebi mater</span>
      <ul>
        {props.keys.map((keyAttributes, index) => {
          return (
            <li key={index} className="KeyElement">
              <Key
                keyValue={keyAttributes}
                availableAttributes={splitAttributes(props.attributes)}
                handleAdd={event => handleAttributeAdd(event, index)}
                handleRemove={event => handleAttributeRemove(event, index)}
              />
              <button onClick={() => handleRemoveKey(index)}>Remove</button>
            </li>
          );
        })}
      </ul>
      <button onClick={props.handleKeyAdd}>Add key</button>
    </div>
  );
};

export default KeysDisplay;
