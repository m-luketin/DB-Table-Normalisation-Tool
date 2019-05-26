import React from "react";
import Navbar from "../components/Navbar";
import "../App.css";

const Algorithm = () => {
  return (
    <>
      <Navbar />
      <div className="algorithm">
        <br />
        <br />
        <br />
        <br />
        <h1 className="algorithm--title">3NF Decomposition algorithm</h1>
        <br />
        <p className="algorithm--description">
          <p className="description--main">
            Third normal form (<b>3NF</b>) is a form used in normalizing a
            database design to reduce data duplication and maintain referential
            integrity by ensuring that{" "}
            <b>the entity is in second normal form </b>
            and that there are no non-prime (non-key) attributes transitively
            dependent of any key <br />
            <br />
          </p>
          <b>It was designed to:</b> <br />
          <b>-</b> eliminate undesirable data anomalies;
          <br />
          <b>-</b> reduce the need for restructuring over time;
          <br />
          <b>-</b> make the data model more informative;
          <br />
          <b>-</b> make the data model neutral to different kind of query
          statistics.
          <br />
          <br />
          <p className="algorithm--steps">
              <b>Steps:</b><br/>
            - RHS of each functional dependency is a single
            attribute (canonical form)
            <br />
            - Create an empty decompositional set
            <br />
            - Add all the elements in a dependency to the set, with the
            condition that they are not already added to the set
            <br />
            - Add the primary key to the set, with the condition that it
            is not already in the set
            <br />
            - The decompositional set now contains tables, whose keys
            can be deduced from the corresponding functional dependencies
            <br />
          </p>
        </p>
      </div>
    </>
  );
};

export default Algorithm;
