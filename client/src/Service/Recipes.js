import instance from "./axios";

const listByCategory = (n, cb) => {
    instance
    .get(`/Recipe/ByCategory?n=${n}`)
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
} 

export { listByCategory };