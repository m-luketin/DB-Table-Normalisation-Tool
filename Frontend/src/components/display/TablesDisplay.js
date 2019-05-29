import React from "react";
import Navbar from "../Navbar";
import Table from "./Table";

const TablesDisplay = props => {
  return (
    <>
      <Navbar />
      <div className="Tables">
        {props.decomposition.TableAttributes.map((table, index) => {
          return (
            <Table table={table} isExample={props.isExample} key={index} />
          );
        })}
      </div>
    </>
  );
};

export default TablesDisplay;
