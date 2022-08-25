import instance from "./axios";

const listByCategory = (id, n, cb) => {
    instance
    .get(`/Recipe/ByCategory?id=${id}&n=${n}`)
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
} 

const search = (req, cb) => {
    instance
    .get(`/Recipe/Search?searchTerm=${req.term}&index=${req.index}&categoryId=${req.id}`)
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
}

const detailed = (id, cb) => {
    instance
    .get(`/Recipe/${id}`)
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
}

const create = (reqData, cb) => {
    instance
    .post("/Recipe", reqData)
    .then((response) => cb(response.data))
    .catch((err) => {
        console.log(err);
        cb(false);
    })
}

export { listByCategory, search, detailed, create };