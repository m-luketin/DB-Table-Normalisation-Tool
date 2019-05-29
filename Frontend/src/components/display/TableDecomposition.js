import React, { Component } from "react";
import Navbar from "../Navbar";
import LoadingScreen from "../LoadingScreen";
import { runAlgorithm } from "../../services/normalization";
import TablesDisplay from "./TablesDisplay";

class TableDecomposition extends Component {
  constructor(props) {
    super(props);
    this.state = {
      SchemaName: null,
      TableAttributes: null
    };
  }

  componentDidMount() {
    const id = this.props.match.params.id;
    runAlgorithm(id).then(response => {
      this.setState({ SchemaName: response.SchemaName, TableAttributes: response.TableAttributes });
    });
  }

  render() {
    if (!this.state.SchemaName)
      return (
        <>
          <Navbar />
          <LoadingScreen />
        </>
      );
    return (
      <>
        <TablesDisplay
          isExample={false}
          decomposition={this.state.state}
        />
      </>
    );
  }
}

export default TableDecomposition;
