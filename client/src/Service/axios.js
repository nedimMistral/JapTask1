import axios from "axios";

const instance = axios.create({
  baseURL: "https://localhost:7024",
});

instance.interceptors.request.use(
  function (config) {
    const token = localStorage.getItem("_jwtToken");
    if (token) {
      config.headers["Authorization"] = `Bearer ${JSON.parse(token)}`;
    }
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

export default instance;
