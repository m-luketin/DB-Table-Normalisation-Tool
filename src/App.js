import React from "react";
import "./App.css";
import Form from "./components/Form";
import Navbar from "./components/Navbar";

function App() {
  return (
    <div className="App">
      <Navbar />
      <Form 
        attributes=""
        keys={[[]]}
        dependenciesLeft={[[]]}
        dependenciesRight={[[]]}
      />
    </div>
  );
}

export default App;
