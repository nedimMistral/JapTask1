import React from "react";
import { Redirect, Route } from "react-router-dom"

import useAuth from "../Hooks/useAuth";
import { pathGenWithParams, routes } from "./routes";
// import { pathGenWithParams, routes } from "./routes";

const Protected = ({component: Component, path}) => {
    let isAuthenticated = useAuth();


    return ( <Route  exact path={path} render={(props) => {
        return isAuthenticated ? (<Component {...props}/>) : (<Redirect to={pathGenWithParams(routes.LOGIN)}/>)
    }}/>)
}

export default Protected;