export const attributeHandler = container => {
  const addAttribute = (attribute, index) => {
    let containerElement = [...container[index], attribute];
    let newContainer = [...container];
    if (container[index].find(element => element === attribute) === undefined)
      newContainer[index] = containerElement;

    return [...newContainer];
  };

  const removeAttribute = (attribute, index) => {
    let containerElement = [...container[index]];
    containerElement = containerElement.filter(
      element => element !== attribute
    );
    let newContainer = [...container];
    newContainer[index] = containerElement;

    return [...newContainer];
  };

  return {
    addAttribute: addAttribute,
    removeAttribute: removeAttribute
  };
};

export const splitAttributes = string => {
  let array = string
    .replace(" ", "")
    .split(",")
    .filter(attribute => !isNullOrWhitespace(attribute));

  return array.map(attribute => {
    return attribute.trim();
  });
};

export const isNullOrWhitespace = input => {
  if (typeof input === "undefined" || input == null) return true;

  return input.replace(/\s/g, "").length < 1;
};

export const formatFormValues = formState => {
  const { keys, dependenciesFrom, dependenciesTo } = formState;

  let newKeys = keys.filter(element => element.length !== 0);
  const newDependenciesFrom = dependenciesFrom.filter(
    (element, index) =>
      element.length !== 0 || dependenciesTo[index].length !== 0
  );
  const newDependenciesTo = dependenciesTo.filter(
    (element, index) =>
      element.length !== 0 || dependenciesFrom[index].length !== 0
  );
  return {
    keys: newKeys,
    dependenciesFrom: newDependenciesFrom,
    dependenciesTo: newDependenciesTo
  };
};

export const getFirstFormattedFormError = formStateValues => {
  // Return values cheat sheet:
  //   1 - attribute error
  //   2 - key error
  //   3 - dependency error
  //   4 - non-existant (redundant) attribute
  //   0 - test passed successfully

  const {
    attributes,
    keys,
    dependenciesFrom,
    dependenciesTo
  } = formStateValues;

  if (isNullOrWhitespace(attributes)) {
    return 1;
  }
  if (keys.length === 0) {
    return 2;
  }
  if (dependenciesFrom.length === 0) {
    return 3;
  }
  if (dependenciesFrom.find(element => element.length === 0) !== undefined) {
    return 3;
  }
  if (dependenciesTo.length === 0) {
    return 3;
  }
  if (dependenciesTo.find(element => element.length === 0) !== undefined) {
    return 3;
  }
  if (isAnyAttributeRedundant(formStateValues)) {
    return 4;
  }

  return 0;
};

const isAnyAttributeRedundant = formStateValues => {
  //This is bad code!
  const {
    attributes,
    keys,
    dependenciesFrom,
    dependenciesTo
  } = formStateValues;
  const attributesArray = splitAttributes(attributes);

  if (
    keys
      .map(key => key.map(att => attributesArray.includes(att)).includes(false))
      .includes(true)
  ) {
    return true;
  }
  if (
    dependenciesFrom
      .map(dependency =>
        dependency.map(att => attributesArray.includes(att)).includes(false)
      )
      .includes(true)
  ) {
    return true;
  }
  if (
    dependenciesTo
      .map(dependency =>
        dependency.map(att => attributesArray.includes(att)).includes(false)
      )
      .includes(true)
  ) {
    return true;
  }

  return false;
};

export const formErrorHandler = formErrorCode => {
  let errorCode = "You are missing some fields in the ";
  switch (formErrorCode) {
    case 1:
      errorCode += "Attributes section!";
      break;
    case 2:
      errorCode += "Keys section!";
      break;
    case 3:
      errorCode += "Functional Dependencies section!";
      break;
    case 4:
      errorCode = "You have added an non-existant attribute!";
      break;
    default:
      errorCode = "Invalid error code!";
  }
  alert(errorCode);
};
