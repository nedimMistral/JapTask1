import instance from "./axios";

const list = (n, cb) => {
    let query = `/Categories?n=${n}`

    if (n === null) {
        query = "/Categories"
    }
    instance
    .get(query)
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
} 

export { list };