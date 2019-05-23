import React, { Component } from "react";
import { isNullOrWhitespace } from "../../utils";
import ReactTooltip from "react-tooltip";

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
        if (
          attribute.toLowerCase().includes(this.state.inputValue.toLowerCase())
        )
          return attribute;
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
            data-tip
            data-for="SearchBar"
            className="AttributeInput"
            onChange={event => this.handleChange(event)}
            onKeyDown={event => this.handleKeyDown(event)}
            value={this.state.inputValue}
          />
          <ReactTooltip className="Tooltip" id="SearchBar" effect="solid">
            <span>You can search for your attributes here</span>
          </ReactTooltip>
          <div className="DropdownContent">
            {this.props.availableAttributes
              .filter(attribute =>
                attribute
                  .toLowerCase()
                  .includes(this.state.inputValue.toLowerCase())
              )
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

        <div
          data-tip
          data-for={this.props.tooltipId}
          className="AttributeOutput"
        >
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

        <ReactTooltip
          className="Tooltip"
          id={this.props.tooltipId}
          effect="solid"
        >
          <span>{this.props.outputTooltip}</span>
        </ReactTooltip>
      </div>
    );
  }
}

export default AttributeSelector;
