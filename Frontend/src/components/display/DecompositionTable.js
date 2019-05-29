import React from "react";

const DecompositionTable = props => {
  return (
    <div className="Table">
      <div className="TableContent">
        <h2>Attributes</h2>
        <div className="TableAttributes">
          {props.attributes.map((attribute, index) => {
            return (
              <div className="TableAttribute" key={index}>
                {attribute}
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default DecompositionTable;