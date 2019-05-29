import React from "react";
import { Link } from "react-router-dom";

const ExampleTable = props => {
  return (
    <div className="Table">
      <div className="TableContent">
        <h2>{props.table.name}</h2>
        <h2>Attributes</h2>
        <div className="TableAttributes">
          {props.table.attributes.map((attribute, index) => {
            return (
              <div className="TableAttribute" key={index}>
                {attribute}
              </div>
            );
          })}
        </div>
      </div>

      <Link to={`update/${props.table.primaryId}`}>
        <button className="ButtonRun ButtonTable">Load table</button>
      </Link>
    </div>
  );
};

export default ExampleTable;
