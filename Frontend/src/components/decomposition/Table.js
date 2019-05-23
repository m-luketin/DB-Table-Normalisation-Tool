import React from "react";

const Table = props => {
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
        
        <h2>Dependencies</h2>
        <div className="TableDependencies">
          {props.dependencies.map((dependency, index) => {
            dependency = dependency.split("-");
            return (
              <div key={index} className="TableDependency">
                <div>{dependency[0]}</div>

                <div> -> </div>

                <div>{dependency[1]}</div>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default Table;
