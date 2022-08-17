import React, { useState } from "react";

import { TextField, Typography } from "@mui/material";

const LoginForm = (props) => {
  [credentials, setCredentials] = useState({ username: "", password: "" });

  const handleFormChange = (e) => {
    setCredentials((prevState) => {
      return { ...prevState, [e.target.name]: e.target.value };
    });
  };

  const onLoginSuccess = (data) => {
    localStorage.setItem("_jwtToken", JSON.stringify(data));
    history.push(generateLink(routes.CATEGORIES));
  };

  const loginHandler = () => {
    sendRequest({
      method: "POST",
      url: "/login",
      data: values,
      additionalFunc: onLoginSuccess,
    });
  };

  return (
    <div>
      <form>
        <Typography variant="h4">Login</Typography>
        <TextField
          name="username"
          label="Username"
          value={credentials.username}
          onChange={handleFormChange}
        />
        <TextField
          name="password"
          label="Password"
          value={credentials.password}
          onChange={handleFormChange}
        />
      </form>
    </div>
  );
};

export default LoginForm;
