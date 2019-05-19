import React, { Component } from "react";
import Attributes from "./Attributes";
import KeysDisplay from "./KeysDisplay";
import DependenciesDisplay from "./DependenciesDisplay";
import Navbar from "./../Navbar";
import { attributeHandler } from "../../utils";

class Form extends Component {
  constructor(props) {
    super(props);
    this.state = {
      attributes: this.props.attributes,
      keys: this.props.keys,
      dependenciesLeft: this.props.dependenciesLeft,
      dependenciesRight: this.props.dependenciesRight
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

  handleKeyChangeAddByEnter = (selectedAttribute, index) => {
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

  handleDependencyChangeAddLeft = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesLeft: attributeHandler(
          prevState.dependenciesLeft
        ).addAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeAddByEnterLeft = (selectedAttribute, index) => {
    this.setState(prevState => {
      return {
        dependenciesLeft: attributeHandler(
          prevState.dependenciesLeft
        ).addAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeAddRight = (event, index) => {
    if (this.state.dependenciesRight[index].length === 1) return;
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesRight: attributeHandler(
          prevState.dependenciesRight
        ).addAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeAddByEnterRight = (selectedAttribute, index) => {
    if (this.state.dependenciesRight[index].length === 1) return;
    this.setState(prevState => {
      return {
        dependenciesRight: attributeHandler(
          prevState.dependenciesRight
        ).addAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeRemoveLeft = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesLeft: attributeHandler(
          prevState.dependenciesLeft
        ).removeAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeRemoveRight = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesRight: attributeHandler(
          prevState.dependenciesRight
        ).removeAttribute(selectedAttribute, index)
      };
    });
  };

  addDependency = () => {
    this.setState(prevState => {
      return {
        dependenciesLeft: [...prevState.dependenciesLeft, []],
        dependenciesRight: [...prevState.dependenciesRight, []]
      };
    });
  };

  removeDependency = index => {
    this.setState(prevState => {
      let newDependenciesLeft = [...prevState.dependenciesLeft];
      newDependenciesLeft.splice(index, 1);
      let newDependenciesRight = [...prevState.dependenciesRight];
      newDependenciesRight.splice(index, 1);
      return {
        dependenciesLeft: [...newDependenciesLeft],
        dependenciesRight: [...newDependenciesRight]
      };
    });
  };

  render() {
    return (
      <>
        <Navbar />
        <div>
          <Attributes
            attributes={this.state.attributes}
            handleChange={this.handleAttributesChange}
          />
          <KeysDisplay
            attributes={this.state.attributes}
            keys={this.state.keys}
            handleAttributeAdd={this.handleKeyChangeAdd}
            handleAttributeAddByEnter={this.handleKeyChangeAddByEnter}
            handleAttributeRemove={this.handleKeyChangeRemove}
            handleKeyAdd={this.addKey}
            handleKeyRemove={this.removeKey}
          />
          <DependenciesDisplay
            attributes={this.state.attributes}
            dependenciesLeft={this.state.dependenciesLeft}
            dependenciesRight={this.state.dependenciesRight}
            handleAttributeAddLeft={this.handleDependencyChangeAddLeft}
            handleAttributeAddRight={this.handleDependencyChangeAddRight}
            handleAttributeAddByEnterLeft={
              this.handleDependencyChangeAddByEnterLeft
            }
            handleAttributeAddByEnterRight={
              this.handleDependencyChangeAddByEnterRight
            }
            handleAttributeRemoveLeft={this.handleDependencyChangeRemoveLeft}
            handleAttributeRemoveRight={this.handleDependencyChangeRemoveRight}
            handleDependencyRemove={this.removeDependency}
            handleDependencyAdd={this.addDependency}
          />
        </div>
      </>
    );
  }
}

export default Form;
