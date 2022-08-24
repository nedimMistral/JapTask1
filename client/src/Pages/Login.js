import React, { useState } from "react";
import { useHistory } from "react-router";

import { Paper, Typography, TextField, Button } from "@mui/material";

import { pathGenWithParams, routes } from "../Router/routes";
import { login } from "../Service/Auth";
import classes from "./Login.module.css";

const Login = () => {
  const [values, setValues] = useState({ username: "", password: "" });
  const [error, setError] = useState(false);
  const history = useHistory();

  const handleFormChange = (e) => {
    setValues((prevState) => {
      return { ...prevState, [e.target.name]: e.target.value };
    });
  };

  const handleSubmit = () => {
    login(values, (resData) => {
      if (resData === null) {
        setError(true);
      } else {
        localStorage.setItem("_jwtToken", JSON.stringify(resData.data));
        history.push(pathGenWithParams(routes.CATEGORIES));
      }
    });
  };

  return (
    <div className={classes.login}>
      <Paper>
        <Typography variant="h5">Recipe app</Typography>
        <form className={classes.form}>
          <TextField
            name="username"
            label="Username"
            value={values.username}
            onChange={handleFormChange}
            className={classes.input}
          />
          <TextField
            name="password"
            label="Password"
            value={values.password}
            onChange={handleFormChange}
            className={classes.input}
            type="password"
          />
          <div>
            <Button onClick={handleSubmit}>Sign in</Button>
          </div>
          {error && (
            <Typography
              variant="body2"
              sx={{ textAlign: "center", color: "red" }}
            >
              Wrong username or password
            </Typography>
          )}
        </form>
      </Paper>
    </div>
  );
};

export default Login;
