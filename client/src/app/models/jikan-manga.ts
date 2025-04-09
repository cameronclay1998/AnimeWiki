import Manga from "./manga"

export interface JikanManga {
    mal_id: string,
    images: Images,
    title: string,
    published: Published,
    authors: Author[],
    genres: Genre[],
    synopsis: string
}

interface Images {
    jpg: Jpg
}

interface Jpg {
    image_url: string
}

interface Published {
    from: string,
    to: string
}

interface Author {
    mal_id: string,
    name: string
}

interface Genre {
    mal_id: string,
    name: string
}

export function mapToManga(jikanManga: JikanManga): Manga {
    return {
        id: jikanManga.mal_id,
        title: jikanManga.title,
        published: jikanManga.published.from,
        description: jikanManga.synopsis,
        author: jikanManga.authors?.[0].name,
        genres: jikanManga.genres.map(g => g.name),
        photos: [{ id: '1', url: jikanManga.images.jpg.image_url, isMain: true }]
    }
}