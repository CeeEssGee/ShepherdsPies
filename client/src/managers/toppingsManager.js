const _apiUrl = "/api/topping";

export const getAllToppings = () => {
    return fetch(_apiUrl).then((res) => res.json());
};

export const GetToppingsByPizzaId = (pizzaId) => {
    return fetch(`${_apiUrl}/pizza${pizzaId}`).then((res) => res.json());
};