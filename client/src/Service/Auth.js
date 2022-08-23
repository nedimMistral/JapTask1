import instance from "./axios.js";

const login = (reqData, cb) => {
  instance
    .post("/Auth/login", reqData)
    .then((response) => cb(response.data))
    .catch((err) => {
      console.log(err);
      cb(false);
    });
};

export { login };