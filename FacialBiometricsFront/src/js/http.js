import axios from 'axios';

const http = axios.create({
    baseURL: 'http://localhost:8793'
});

export default http;