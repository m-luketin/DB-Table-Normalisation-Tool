import React, { Component } from "react";
import Key from "./Key";
import { attributeHandler } from "./../utils";

class KeysDisplay extends Component {
  constructor(props) {
    super(props);
    this.state = {
      keys: [[]]
    };
  }

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
    const splitAttributes = string => {
      return string.replace(" ", "").split(",");
    };
    return (
      <div>
        <h1>Keys in table</h1>
        <span>Jebi mater</span>
        <ul>
          {this.state.keys.map((keyAttributes, index) => {
            return (
              <li key={index} className="KeyElement">
                <Key
                  keyValue={keyAttributes}
                  availableAttributes={splitAttributes(this.props.attributes)}
                  handleAdd={event => this.handleKeyChangeAdd(event, index)}
                  handleRemove={event =>
                    this.handleKeyChangeRemove(event, index)
                  }
                />
                <button onClick={() => this.removeKey(index)}>Remove</button>
              </li>
            );
          })}
        </ul>
        <button onClick={this.addKey}>Add key</button>
      </div>
    );
  }
}

export default KeysDisplay;
