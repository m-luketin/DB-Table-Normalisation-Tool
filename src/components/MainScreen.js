import React from "react";
import Navbar from "./Navbar";

const MainScreen = () => {
  return (
    <>
      <Navbar />
      <div className="MainScreen">
        <h1 className="MainTitle">Database table normalization tool</h1>
        <p className="MainDescription">
          This tool is designed as part of a seminar assignment for the course
          Databases 2. Made using Entity Framework Core on the backend and React
          on the frontend. The main function of the tool is to normalize a given
          or stored table to the <b>Third normal form</b> (3NF) using the given
          set of <b>Attributes</b> (Relation scheme), <b>Keys</b> and{" "}
          <b>Functional</b> dependencies.
        </p>
        <h2>Created by:</h2>
        <p className="MainDescription CreatedBy">
          <a
            href="https://github.com/AnteVuletic"
            target="_blank"
            rel="noopener noreferrer"
          >
            Ante Vuletić
          </a>
          ,{" "}
          <a
            href="https://github.com/m-luketin"
            target="_blank"
            rel="noopener noreferrer"
          >
            Matija Luketin
          </a>
          , and{" "}
          <a
            href="https://github.com/AAmanzi"
            target="_blank"
            rel="noopener noreferrer"
          >
            Alex Amanzi
          </a>
        </p>
      </div>
    </>
  );
};

export default MainScreen;
