import React from "react";
import Key from "./Key";
import { splitAttributes, isNullOrWhitespace } from "./../utils";

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
      <div className="KeyContent">
        <ul>
          {props.keys.map((keyAttributes, index) => {
            return (
              <li key={index} className="KeyElement">
                <Key
                  index={index}
                  value={keyAttributes}
                  availableAttributes={
                    isNullOrWhitespace(props.attributes)
                      ? []
                      : splitAttributes(props.attributes)
                  }
                  handleAdd={event => handleAttributeAdd(event, index)}
                  handleAddByEnter={props.handleAttributeAddByEnter}
                  handleRemove={event => handleAttributeRemove(event, index)}
                />
                <button
                  className="Button ButtonRemove"
                  onClick={() => handleKeyRemove(index)}
                >
                  <svg height="40" width="40">
                    <line className="SvgLine" x1="10" y1="20" x2="30" y2="20" />
                  </svg>
                </button>
              </li>
            );
          })}
        </ul>

        <button className="Button ButtonAdd" onClick={props.handleKeyAdd}>
          <svg height="40" width="40">
            <line className="SvgLine" x1="10" y1="20" x2="30" y2="20" />
            <line className="SvgLine" x1="20" y1="10" x2="20" y2="30" />
          </svg>
        </button>
      </div>
    </div>
  );
};

export default KeysDisplay;
