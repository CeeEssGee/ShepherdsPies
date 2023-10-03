const _apiUrl = "/api/userProfile";

export const getAllUsers = () => {
    return fetch(_apiUrl).then((res) => res.json());
};