import { useCallback, useState } from "react";
import axios from "../Service/axios";

const useAxios = () => {
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  const request = useCallback(
    ({ url, method, params, data, resData, additionalFunc }) => {
      axios({
        url: url,
        method: method,
        params: params,
        headers: { "Content-Type": "application/json" },
        data: method === "GET" ? null : data,
      })
        .then((response) => {
          setResponse(response.data.data);

          setLoading(false);
          additionalFunc && additionalFunc(response.data.data);
        })
        .catch((err) => {
          setError(err.message);
          setLoading(false);
        });
    },
    []
  );

  return {
    response,
    error,
    loading,
    request,
  };
};

export default useAxios;
