import React from "react";
import { Link } from "react-router-dom";

const Table = props => {
  return (
    <div className="Table">
      <div className="TableContent">
        {props.isExample === true ? <h2>{props.table.name}</h2> : null}
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

        {props.isExample !== true ? (
          <>
            <h2>Dependencies</h2>
            <div className="TableDependencies">
              {props.table.dependencies.map((dependency, index) => {
                return (
                  <div key={index} className="TableDependency">
                    <div>{dependency.from}</div>

                    <div> -> </div>

                    <div>{dependency.to}</div>
                  </div>
                );
              })}
            </div>
          </>
        ) : null}
      </div>
      {props.isExample === true ? (
        <Link to={`update/${props.table.primaryId}`}>
          <button className="ButtonRun ButtonTable">Load table</button>
        </Link>
      ) : null}
    </div>
  );
};

export default Table;
