import instance from "./axios";

const list = (n, cb) => {
    instance
    .get(`/Categories?n=${n}`)
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
} 

export { list };