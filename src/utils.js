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
