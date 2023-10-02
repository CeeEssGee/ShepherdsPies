const _apiURL = "/api/order";

export const getOrders = () => {
    return fetch(_apiURL)
        .then((res) => res.json());
};

export const getOrderById = (id) => {
    return fetch(`${_apiURL}/${id}`)
        .then((res) => res.json());
};

export const deleteOrder = (id) => {
    return fetch(`${_apiURL}/${id}`, {
        method: "DELETE"
    });
};