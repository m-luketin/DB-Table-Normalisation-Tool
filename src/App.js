import React from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import "./fonts/stylesheet.css";
import "./App.css";
import MainScreen from "./components/MainScreen";
import Form from "./components/form/Form";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Switch>
          <Route exact path="/" render={() => <MainScreen />} />
          <Route
            exact
            path="/create"
            render={() => (
              <Form
                attributes=""
                keys={[[]]}
                dependenciesLeft={[[]]}
                dependenciesRight={[[]]}
              />
            )}
          />
          <Redirect to="/" />
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
