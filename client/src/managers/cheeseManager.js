const _apiUrl = "/api/cheese";

export const getAllCheeses = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const getCheeseById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};