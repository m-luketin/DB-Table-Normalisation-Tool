import React, { Component } from "react";
import Navbar from "../Navbar";
import LoadingScreen from "../LoadingScreen";
import { runAlgorithm } from "../../services/normalization";
import TablesDisplay from "./TablesDisplay";

class TableDecomposition extends Component {
  constructor(props) {
    super(props);
    this.state = {
      decomposition: null
    };
  }

  componentDidMount() {
    const id = this.props.match.params.id;
    runAlgorithm(id).then(response => {
      this.setState({ decomposition: response });
    });
  }

  render() {
    if (!this.state.decomposition)
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
          decomposition={this.state.decomposition}
        />
      </>
    );
  }
}

export default TableDecomposition;
