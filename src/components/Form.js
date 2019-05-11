import React, { Component } from "react";
import Attributes from "./Attributes";
import KeysDisplay from "./KeysDisplay";
import { attributeHandler } from "./../utils";

class Form extends Component {
  constructor(props) {
    super(props);
    this.state = {
      attributes: "",
      keys: [[]]
    };
  }

  handleAttributesChange = event => {
    this.setState({ attributes: event.target.value });
  };

  handleKeyChangeAdd = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        keys: attributeHandler(prevState.keys).addAttribute(
          selectedAttribute,
          index
        )
      };
    });
  };

  handleKeyChangeRemove = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        keys: attributeHandler(prevState.keys).removeAttribute(
          selectedAttribute,
          index
        )
      };
    });
  };

  addKey = () => {
    this.setState(prevState => {
      return {
        keys: [...prevState.keys, []]
      };
    });
  };

  removeKey = index => {
    this.setState(prevState => {
      let newKeys = [...prevState.keys];
      newKeys.splice(index, 1);
      return {
        keys: [...newKeys]
      };
    });
  };

  render() {
    return (
      <div>
        <Attributes
          attributes={this.state.attributes}
          handleChange={this.handleAttributesChange}
        />
        <KeysDisplay
          attributes={this.state.attributes}
          keys={this.state.keys}
          handleAttributeAdd={this.handleKeyChangeAdd}
          handleAttributeRemove={this.handleKeyChangeRemove}
          handleKeyAdd={this.addKey}
          handleKeyRemove={this.removeKey}
        />
        {/* <FunctionalDependencies /> */}
      </div>
    );
  }
}

export default Form;
