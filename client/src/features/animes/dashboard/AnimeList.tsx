import { Button, Item, Label, List, Segment } from "semantic-ui-react"
import { Anime } from "../../../app/models/anime"
import './anime-list.css'
import AnimeGenreList from "./AnimeGenreList"

interface Props {
    animes: Anime[]
    handleSelectAnime: (id: string) => void
}

export default function AnimeList({ animes, handleSelectAnime }: Props) {
    console.log(animes.length)
    return (
        <Segment className='dark-theme'>
            {
                animes.length < 1 ?
                    <div>No Content</div> :
                    <Item.Group>
                        {
                            animes.map(anime => {
                                return (
                                    <Item className='anime-item' key={anime.id}>
                                        <Item.Content>
                                            <Item.Header as='a'>{anime.title}</Item.Header>
                                            <Item.Meta>{anime.releaseDate}</Item.Meta>
                                            <Item.Description>{anime.description}</Item.Description>
                                            <Item.Extra>
                                                <Button
                                                    className='unset-dark-theme'
                                                    onClick={() => { handleSelectAnime(anime.id) }}
                                                    floated='right'
                                                    inverted
                                                    content='View'
                                                    color='purple'
                                                />
                                                <AnimeGenreList anime={anime} />
                                            </Item.Extra>
                                        </Item.Content>
                                    </Item>
                                )
                            })
                        }
                    </Item.Group>
            }
        </Segment>
    )
}