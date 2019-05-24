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
  return string
    .replace(" ", "")
    .split(",")
    .filter(attribute => !isNullOrWhitespace(attribute));
};

export const isNullOrWhitespace = input => {
  if (typeof input === "undefined" || input == null) return true;

  return input.replace(/\s/g, "").length < 1;
};

export const formatFormValues = formState => {
  const { keys, dependenciesFrom, dependenciesTo } = formState;

  const newKeys = keys.filter(element => element.length !== 0);
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
  return 0;
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
    default:
      errorCode = "Invalid error code!";
  }
  alert(errorCode);
};
