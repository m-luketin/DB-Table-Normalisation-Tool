import React, { Component } from "react";
import Attributes from "./Attributes";
import KeysDisplay from "./KeysDisplay"

class Form extends Component {
  constructor(props) {
    super(props);
    this.state = {
      attributes: ""
    };
  }

  handleAttributesChange = event => {
    this.setState({ attributes: event.target.value });
  };

  render() {
    return (
      <div>
        <Attributes
          attributes={this.state.attributes}
          handleChange={this.handleAttributesChange}
        />
        <KeysDisplay attributes={this.state.attributes}/>
         {/* <FunctionalDependencies /> */}
      </div>
    );
  }
}

export default Form;
