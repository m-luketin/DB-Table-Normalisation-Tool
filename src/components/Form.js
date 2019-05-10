import React, { Component } from "react";
import Attributes from "./Attributes";

class Form extends Component {
  constructor(props) {
    super(props);
    this.state = {
      attributes: ""
    };
  }

  handleAttributesChange = event => {
    console.log(this.state.attributes);
    this.setState({ attributes: event.target.value });
  };

  render() {
    return (
      <div>
        <Attributes
          attributes={this.state.attributes}
          handleChange={this.handleAttributesChange}
        />
        {/* <Keys />
        <FunctionalDependencies /> */}
      </div>
    );
  }
}

export default Form;
