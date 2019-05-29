import React, { Component } from "react";
import Navbar from "../Navbar";
import LoadingScreen from "../LoadingScreen";
import { fetchStoredTables } from "../../services/normalization";
import TablesDisplay from "./TablesDisplay";

class TablesLoad extends Component {
  constructor(props) {
    super(props);
    this.state = {
      decomposition: null
    };
  }

  componentDidMount() {
    fetchStoredTables().then(response => {
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
          isExample={true}
          decomposition={this.state.decomposition}
        />
      </>
    );
  }
}

export default TablesLoad;
