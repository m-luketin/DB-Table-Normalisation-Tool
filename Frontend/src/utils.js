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
  return string.replace(" ", "").split(",").filter(attribute => !isNullOrWhitespace(attribute));
};

export const isNullOrWhitespace = input => {
  if (typeof input === "undefined" || input == null) return true;

  return input.replace(/\s/g, "").length < 1;
};
