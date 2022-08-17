import React from "react";
import { Redirect } from "react-router-dom"

import useAuth from "../Hooks/useAuth";
import { pathGenWithParams, routes } from "./routes";

const ProtectedRoute = (children) => {
    if (!useAuth()) {
        return <Redirect to={pathGenWithParams(routes.LOGIN)} />
    }

    return children;
}

export default ProtectedRoute;