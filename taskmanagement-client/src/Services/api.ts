import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7189/api"
});

export default api;