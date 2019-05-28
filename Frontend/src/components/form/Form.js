import React, { Component } from "react";
import InputField from "./InputField";
import KeysDisplay from "./KeysDisplay";
import DependenciesDisplay from "./DependenciesDisplay";
import Navbar from "./../Navbar";
import {
  attributeHandler,
  splitAttributes,
  getFirstFormattedFormError,
  formatFormValues,
  formErrorHandler
} from "../../utils";
import { postTable } from "../../services/normalization";

class Form extends Component {
  constructor(props) {
    super(props);
    this.state = {
      tableName: this.props.tableName,
      attributes: this.props.attributes,
      keys: this.props.keys,
      dependenciesFrom: this.props.dependenciesFrom,
      dependenciesTo: this.props.dependenciesTo
    };
  }

  handleNameChange = event => {
    this.setState({ tableName: event.target.value });
  };

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

  handleDependencyChangeAddFrom = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesFrom: attributeHandler(
          prevState.dependenciesFrom
        ).addAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeAddByEnterFrom = (selectedAttribute, index) => {
    this.setState(prevState => {
      return {
        dependenciesFrom: attributeHandler(
          prevState.dependenciesFrom
        ).addAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeAddTo = (event, index) => {
    if (this.state.dependenciesTo[index].length === 1) return;
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesTo: attributeHandler(prevState.dependenciesTo).addAttribute(
          selectedAttribute,
          index
        )
      };
    });
  };

  handleDependencyChangeAddByEnterTo = (selectedAttribute, index) => {
    if (this.state.dependenciesTo[index].length === 1) return;
    this.setState(prevState => {
      return {
        dependenciesTo: attributeHandler(prevState.dependenciesTo).addAttribute(
          selectedAttribute,
          index
        )
      };
    });
  };

  handleDependencyChangeRemoveFrom = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesFrom: attributeHandler(
          prevState.dependenciesFrom
        ).removeAttribute(selectedAttribute, index)
      };
    });
  };

  handleDependencyChangeRemoveTo = (event, index) => {
    const selectedAttribute = event.target.innerHTML;
    this.setState(prevState => {
      return {
        dependenciesTo: attributeHandler(
          prevState.dependenciesTo
        ).removeAttribute(selectedAttribute, index)
      };
    });
  };

  addDependency = () => {
    this.setState(prevState => {
      return {
        dependenciesFrom: [...prevState.dependenciesFrom, []],
        dependenciesTo: [...prevState.dependenciesTo, []]
      };
    });
  };

  removeDependency = index => {
    this.setState(prevState => {
      let newdependenciesFrom = [...prevState.dependenciesFrom];
      newdependenciesFrom.splice(index, 1);
      let newdependenciesTo = [...prevState.dependenciesTo];
      newdependenciesTo.splice(index, 1);
      return {
        dependenciesFrom: [...newdependenciesFrom],
        dependenciesTo: [...newdependenciesTo]
      };
    });
  };

  clearState = () => {
    this.setState({
      attributes: "",
      keys: [[]],
      dependenciesFrom: [[]],
      dependenciesTo: [[]]
    });
  };

  postForm = () => {
    const formattedFormValues = formatFormValues(this.state);
    const attributes = this.state.attributes;
    const {
      tableName,
      keys,
      dependenciesFrom,
      dependenciesTo
    } = formattedFormValues;

    const formError = getFirstFormattedFormError({
      tableName,
      attributes,
      keys,
      dependenciesFrom,
      dependenciesTo
    });

    if (formError !== 0) {
      formErrorHandler(formError);
      return;
    }

    const Dependencies = dependenciesFrom.map((dependencyFrom, index) => {
      return {
        PrimaryId: -1,
        From: dependencyFrom,
        To: dependenciesTo[index].toString()
      };
    });
    const endpointCorrect = {
      Name: tableName,
      Attributes: splitAttributes(attributes),
      Dependencies: [...Dependencies],
      Keys: keys,
      PrimaryId: -1
    };
    console.log(endpointCorrect);
    postTable(endpointCorrect).then(response => console.log(response));
    console.log(dependenciesFrom);
  };

  render() {
    return (
      <>
        <Navbar />
        <div className="Form">
          <InputField
            heading="Table name"
            description="Your table will be saved using the name provided"
            value={this.state.tableName}
            handleChange={this.handleNameChange}
          />
          <InputField
            heading="Attributes in table"
            description="Separate attributes using a comma ( , )"
            value={this.state.attributes}
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
            dependenciesFrom={this.state.dependenciesFrom}
            dependenciesTo={this.state.dependenciesTo}
            handleAttributeAddFrom={this.handleDependencyChangeAddFrom}
            handleAttributeAddTo={this.handleDependencyChangeAddTo}
            handleAttributeAddByEnterFrom={
              this.handleDependencyChangeAddByEnterFrom
            }
            handleAttributeAddByEnterTo={
              this.handleDependencyChangeAddByEnterTo
            }
            handleAttributeRemoveFrom={this.handleDependencyChangeRemoveFrom}
            handleAttributeRemoveTo={this.handleDependencyChangeRemoveTo}
            handleDependencyRemove={this.removeDependency}
            handleDependencyAdd={this.addDependency}
          />
          <div className="FormButtonContainer">
            <button className="ButtonRun ButtonClear" onClick={this.clearState}>
              Clear all inputs
            </button>
            <button className="ButtonRun" onClick={this.postForm}>
              Save and run
            </button>
          </div>
        </div>
      </>
    );
  }
}

export default Form;
