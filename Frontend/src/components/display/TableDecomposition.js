import React, { Component } from "react";
import Navbar from "../Navbar";
import LoadingScreen from "../LoadingScreen";
import { runAlgorithm } from "../../services/normalization";
import DecompositionDisplay from "./DecompositionDisplay"

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
      this.setState({ SchemaName: response.schemaName, TableAttributes: response.tableAttributes });
    });
  }

  render() {
    console.log(this.state)
    if (!this.state.SchemaName)
      return (
        <>
          <Navbar />
          <LoadingScreen />
        </>
      );
    return (
      <>
        <h2>{this.state.SchemaName}</h2>
        {this.state.TableAttributes.map((table,index)=>{
          return <DecompositionDisplay
            key={index}
            table={table}
          />
        })
        }
      </>
    );
  }
}

export default TableDecomposition;
