import jwt from "jsonwebtoken";

const getUserId = () => {
  const token = JSON.parse(localStorage.getItem("_jwtToken"));
  const decoded = jwt.decode(token);

  return decoded.nameid;
};

export default getUserId;