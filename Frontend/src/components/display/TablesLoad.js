import React, { Component } from "react";
import Navbar from "../Navbar";
import LoadingScreen from "../LoadingScreen";
import { fetchStoredTables, deleteTable } from "../../services/normalization";
import TablesDisplay from "./TablesDisplay";

class TablesLoad extends Component {
  constructor(props) {
    super(props);
    this.state = {
      decomposition: null
    };
  }

  handleDeleteTable = table => {
    if (window.confirm("Are you sure you want to delete this table?"))
      deleteTable(table);
    this.setState(prevState => {
      let newDecomposition = [...prevState.decomposition].filter(
        element => element !== table
      );
      return {
        decomposition: newDecomposition
      };
    });
  };

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
          handleTableDelete={this.handleDeleteTable}
        />
      </>
    );
  }
}

export default TablesLoad;
