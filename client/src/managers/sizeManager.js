const _apiUrl = "/api/size";

export const getAllSizes = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const getSizeById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
}