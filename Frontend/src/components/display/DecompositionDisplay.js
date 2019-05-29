import React from "react";
import { Link } from "react-router-dom";
import DecompositionTable from "./DecompositionTable";
import Navbar from "../Navbar";

const DecompositionDisplay = props => {
  return (
    <>
      <Navbar />
      <Link to={`/update/${props.id}`}>
        <h2 className="TableSchemaName">{props.schemaName}</h2>
      </Link>
      <div className="Tables">
        {props.decomposition.map((tableAttributes, index) => {
          return (
            <DecompositionTable attributes={tableAttributes} key={index} />
          );
        })}
      </div>
    </>
  );
};
export default DecompositionDisplay;
