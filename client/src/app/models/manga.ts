import { Photo } from "./photo"

export default interface Manga {
    id: string,
    title: string,
    published: string,
    description: string,
    author: string,
    genres: string[]
    photos: Photo[]
}