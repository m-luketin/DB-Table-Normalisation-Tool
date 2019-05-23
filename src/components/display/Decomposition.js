import React from "react";
import Navbar from "../Navbar";
import Table from "./Table";

const Decomposition = props => {
  return (
    <>
      <Navbar />
      <div className="Tables">
        <Table
          attributes={["a", "b", "c", "d"]}
          dependencies={["a,b-c", "c,d-a"]}
        />
        <Table
          attributes={["a", "b", "c", "d"]}
          dependencies={["a,b-c", "c,d-a", "c,d-a", "c,d-a", "c,d-a"]}
        />
        <Table
          attributes={["a", "b", "c", "d"]}
          dependencies={["a,b-c"]}
        />
        <Table
          attributes={["a", "b", "c", "d"]}
          dependencies={["a,b-c", "c,d-a"]}
        />
        <Table
          attributes={["a", "b", "c", "d"]}
          dependencies={["a,b-c", "c,d-a"]}
        />
        <Table
          attributes={["a", "b", "c", "d"]}
          dependencies={["a,b-c", "c,d-a"]}
        />
      </div>
    </>
  );
};

export default Decomposition;
