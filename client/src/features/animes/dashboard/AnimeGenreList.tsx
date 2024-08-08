import { List } from "semantic-ui-react"
import { Anime } from "../../../app/models/anime"

interface Props {
    anime: Anime
}

export default function AnimeGenreList({ anime } : Props) {
    return (
        <List className='anime-genre-list' horizontal>
            {anime.genres.map(genre => {
                return (
                    <List.Item key={genre}>
                        <List.Content><p>{genre}</p></List.Content>
                    </List.Item>
                )
            })}
        </List>
    )
}