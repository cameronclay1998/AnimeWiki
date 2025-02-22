import axios, { AxiosResponse } from 'axios';
import { Anime } from '../models/anime';
import Manga from '../models/manga';

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody)
}

const Animes = {
    list: () => requests.get<Anime[]>('/animes'),
    details: (id: string) => requests.get<Anime>(`/animes/${id}`),
    create: (anime: Anime) => requests.post<Anime>('/animes', anime),
    edit: (anime: Anime) => requests.put<Anime>(`/animes/${anime.id}`, anime),
    delete: (id: string) => requests.delete<void>(`animes/${id}`)
}

const Mangas = {
    list: () => requests.get<Manga[]>('/mangas')
}

const agent = {
    Animes,
    Mangas
}

export default agent;