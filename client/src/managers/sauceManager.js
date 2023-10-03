const _apiUrl = "/api/sauce";

export const getAllSauces = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const getSauceById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};