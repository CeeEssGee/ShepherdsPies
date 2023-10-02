const _apiURL = "/api/pizza";

export const getPizzas = () => {
    return fetch(_apiURL)
        .then((res) => res.json());
};

export const getPizzaById = (id) => {
    return fetch(`${_apiURL}/${id}`)
        .then((res) => res.json());
};

export const deletePizza = (id) => {
    return fetch(`${_apiURL}/${id}`, {
        method: "DELETE"
    });
};