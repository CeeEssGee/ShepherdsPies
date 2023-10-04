const _apiURL = "/api/order";

export const getOrders = () => {
    return fetch(_apiURL)
        .then((res) => res.json());
};

export const getTodaysOrders = () => {
    return fetch(`${_apiURL}/today`)
        .then((res) => res.json());
};

export const fetchNewestFirst = () => {
    return fetch(`${_apiURL}/newest`)
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

export const postOrder = (order) => {
    return fetch(_apiURL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(order)
    }).then((res) => res.json());
};

export const putOrder = (id, order) => {
    return fetch(`${_apiURL}/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(order)
    });
}