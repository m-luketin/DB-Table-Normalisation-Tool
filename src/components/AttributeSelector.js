import React from "react";

const AttributeSelector = props => {
  return (
    <div className="Dropdown">
      <div className="KeyInput" type="text">
        {props.keyValue.map((value, index) => {
          return (
            <button
              key={index}
              className="KeyInputElement"
              onClick={props.handleRemove}
            >
              {value}
            </button>
          );
        })}
      </div>
      <div className="DropdownContent">
        {props.availableAttributes.map((attribute, index) => (
          <button
            key={index}
            className="DropdownAttribute"
            onClick={props.handleAdd}
          >
            {attribute}
          </button>
        ))}
      </div>
    </div>
  );
};

export default AttributeSelector;
