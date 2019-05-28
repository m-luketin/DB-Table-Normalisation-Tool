import React, { Component } from "react";
import Navbar from "../Navbar";
import Table from "./Table";
import LoadingScreen from "../LoadingScreen";
import { fetchStoredTables } from "../../services/normalization";

class Decomposition extends Component {
  constructor(props) {
    super(props);
    this.state = {
      decomposition: null
    };
  }

  // componentDidMount(){
  //   fetchStoredTables().then(response => {
  //     this.setState({decomposition: response});
  //   })
  // }

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
        <Navbar />
        <div className="Tables">
          {this.state.decomposition.map((table, index) => (
            <Table
              title={table.name}
              attributes={table.attributes}
              key={index}
            />
          ))}
        </div>
      </>
    );
  }
}

export default Decomposition;
