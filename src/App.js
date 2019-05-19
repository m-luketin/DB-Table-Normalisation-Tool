import React from "react";
import "./App.css";
import Form from "./components/form/Form";
import Decomposition from "./components/decomposition/Decomposition";
import "./fonts/stylesheet.css";

function App() {
  return (
    <div className="App">
      {/* <Form 
        attributes=""
        keys={[[]]}
        dependenciesLeft={[[]]}
        dependenciesRight={[[]]}
      /> */}
      <Decomposition />
    </div>
  );
}

export default App;
