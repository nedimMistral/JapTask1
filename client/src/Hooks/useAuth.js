import jwt from "jsonwebtoken";

const useAuth = () => {
  let verified = true;

  const token = JSON.parse(localStorage.getItem("_jwtToken"));

  if (!token) {
    return false;
  } 
  
  jwt.verify(token, process.env.REACT_APP_SECRET, function (err, decoded) {
    if (err) {
      verified = false;
    }
  });
  
  return verified;
};

export default useAuth;