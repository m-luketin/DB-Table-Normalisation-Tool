import React, { Component } from "react";
import Navbar from "../Navbar";
import LoadingScreen from "../LoadingScreen";
import { runAlgorithm } from "../../services/normalization";
import DecompositionDisplay from "./DecompositionDisplay";

class TableDecomposition extends Component {
  constructor(props) {
    super(props);
    this.state = {
      schema: null
    };
  }

  componentDidMount() {
    const id = this.props.match.params.id;
    runAlgorithm(id).then(response => {
      this.setState({ schema: response });
    });
  }

  render() {
    if (!this.state.schema)
      return (
        <>
          <Navbar />
          <LoadingScreen />
        </>
      );
    return (
      <>
        <DecompositionDisplay
          schemaName={this.state.schema.schemaName}
          decomposition={this.state.schema.tableAttributes}
          id={this.props.match.params.id}
        />
      </>
    );
  }
}

export default TableDecomposition;
