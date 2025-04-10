import axios, { AxiosResponse } from 'axios';
import { Anime } from '../models/anime';
import Manga from '../models/manga';
import { JikanManga, mapToManga } from '../models/jikan-manga';
import { Character } from '../models/jikan-character';

const useJikan = true;

axios.defaults.baseURL = useJikan ? 'https://api.jikan.moe/v4' : 'http://localhost:5000/api';

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

interface JikanMangaResponse {
    pagination: Pagination,
    data: JikanManga[]
}

interface Pagination {
    last_visible_page: number,
    has_next_page: boolean
}

const Mangas = useJikan ? {
    list: () => requests.get<JikanMangaResponse>('/manga?sfw=true')
        .then((res): Manga[] => res.data.map(m => mapToManga(m)))
} : {
    list: () => requests.get<Manga[]>('/mangas')
}

interface MangaCharactersResponse {
    data: CharacterInfo[]
}

export interface CharacterInfo {
    character: Character,
    role: string
}

const Jikan = {
    mangaCharacters: (id: string) => requests.get<MangaCharactersResponse>(`/manga/${id}/characters`)
}

const agent = {
    Animes,
    Mangas,
    Jikan
}

export default agent;