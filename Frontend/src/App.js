import React from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
import "./fonts/stylesheet.css";
import "./App.css";
import "./Loading.css";
import MainScreen from "./components/MainScreen";
import Form from "./components/form/Form";
import FormLoad from "./components/form/FormLoad";
import Decomposition from "./components/display/Decomposition";
import Algorithm from "./components/Algorithm";

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
                tableName=""
                attributes=""
                keys={[[]]}
                dependenciesFrom={[[]]}
                dependenciesTo={[[]]}
              />
            )}
          />
          <Route
            exact
            path="/update/:id"
            render={props => <FormLoad {...props} />}
          />
          <Route exact path="/load" render={() => <Decomposition />} />
          <Route exact path="/algorithm" render={() => <Algorithm />} />
          <Redirect to="/" />
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
