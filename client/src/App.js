import { Redirect, Route, Switch } from "react-router-dom";

import useAuth from "./Hooks/useAuth";
import { pathGenWithParams, routes } from "./Router/routes";
import Router from "./Router/Router";
import Login from "./Pages/Login";

import "./App.css";




function App() {
  const { isLogged } = useAuth();

  return (
    <div className="App">
      <Switch>
        <Route exact path="/" render={() => {
          return isLogged ? (<Redirect to={pathGenWithParams(routes.CATEGORIES)}/>) : <Login/>
        }} />
      </Switch>
      <Router />
    </div>
  );
}

export default App;
