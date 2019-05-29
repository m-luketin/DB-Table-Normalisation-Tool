import React, { Component } from "react";
import { fetchTableById } from "../../services/normalization";
import Form from "./Form";
import Navbar from "../Navbar";
import LoadingScreen from "../LoadingScreen";

class FormLoad extends Component {
  constructor(props) {
    super(props);
    this.state = {
      table: null,
      dependenciesFrom: null,
      dependenciesTo: null
    };
  }

  componentDidMount() {
    const id = this.props.match.params.id;
    fetchTableById(id).then(response => {
      this.setState(() => {
        return {
          table: response,
          dependenciesFrom: response.dependencies.map(element => element.from),
          dependenciesTo: response.dependencies.map(element => [element.to])
        };
      });
    });
  }

  render() {
    if (!this.state.table)
      return (
        <>
          <Navbar />
          <LoadingScreen />
        </>
      );
    return (
      <Form
        tableName={this.state.table.name}
        attributes={this.state.table.attributes.join(", ")}
        keys={this.state.table.keys}
        dependenciesFrom={this.state.dependenciesFrom}
        dependenciesTo={this.state.dependenciesTo}
        id={this.state.table.primaryId}
      />
    );
  }
}

export default FormLoad;
