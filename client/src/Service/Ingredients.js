import instance from "./axios";

const list = (cb) => {
    instance
    .get("/Ingredients")
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
} 

export { list };