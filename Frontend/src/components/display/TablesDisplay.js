import React from "react";
import Navbar from "../Navbar";
import ExampleTable from "./ExampleTable";

const TablesDisplay = props => {
  return (
    <>
      <Navbar />
      <div className="Tables">
        {props.decomposition.map((table, index) => {
          return <ExampleTable table={table} key={index} />;
        })}
      </div>
    </>
  );
};

export default TablesDisplay;
