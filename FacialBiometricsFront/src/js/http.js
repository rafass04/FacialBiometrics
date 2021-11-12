import axios from 'axios';

const http = axios.create({
    baseURL: 'https://localhost:44343'
});

export default http;