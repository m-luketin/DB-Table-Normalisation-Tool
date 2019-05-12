import React, { Component } from "react";
import { isNullOrWhitespace } from "./../utils";

class AttributeSelector extends Component {
  constructor(props) {
    super(props);
    this.state = {
      inputValue: ""
    };
  }

  handleChange = event => {
    const text = event.target.value;
    this.setState(() => {
      if (isNullOrWhitespace(text)) return { inputValue: "" };
      return { inputValue: text };
    });
  };

  handleKeyDown = event => {
    if (event.key === "Enter") {
      let attributeToAdd = this.props.availableAttributes.map(attribute => {
        if (attribute.includes(this.state.inputValue)) return attribute;
        return undefined;
      });
      this.setState({ inputValue: "" });
      attributeToAdd = attributeToAdd.filter(
        element => element !== undefined
      )[0];
      

      if (
        attributeToAdd === undefined ||
        !this.props.availableAttributes.find(
          attribute => attribute === attributeToAdd
        )
      )
        return;
        
      this.props.handleAddByEnter(attributeToAdd, this.props.index);
    }
  };

  render() {
    return (
      <div className="AttributeSelector">
        <div className="Dropdown">
          <textarea
            className="AttributeInput"
            onChange={event => this.handleChange(event)}
            onKeyDown={event => this.handleKeyDown(event)}
            value={this.state.inputValue}
          />
          <div className="DropdownContent">
            {this.props.availableAttributes
              .filter(attribute => attribute.includes(this.state.inputValue))
              .map((attribute, index) => (
                <button
                  key={index}
                  className="DropdownAttribute"
                  onClick={this.props.handleAdd}
                >
                  {attribute}
                </button>
              ))}
          </div>
        </div>

        <div className="AttributeOutput">
          {this.props.value.map((value, index) => {
            return (
              <button
                key={index}
                className="ButtonSmall"
                onClick={this.props.handleRemove}
              >
                {value}
              </button>
            );
          })}
        </div>
      </div>
    );
  }
}

export default AttributeSelector;
