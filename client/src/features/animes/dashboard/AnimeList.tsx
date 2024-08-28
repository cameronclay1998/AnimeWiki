import { Button, ButtonGroup, Container, Item, Segment } from "semantic-ui-react"
import { Anime } from "../../../app/models/anime"
import './anime-list.css'
import AnimeGenreList from "./AnimeGenreList"

interface Props {
    animes: Anime[]
    handleSelectAnime: (id: string) => void
    handleDeleteAnime: (id: string) => void
}

export default function AnimeList({ animes, handleSelectAnime, handleDeleteAnime }: Props) {
    return (
        <Container className='dark-theme'>
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
                                                <ButtonGroup floated="right">
                                                    <Button
                                                        onClick={() => { handleDeleteAnime(anime.id) }}
                                                        floated='right'
                                                        inverted
                                                        content='Delete'
                                                        color='red'
                                                    />
                                                    <Button
                                                        onClick={() => { handleSelectAnime(anime.id) }}
                                                        floated='right'
                                                        inverted
                                                        content='View'
                                                        color='purple'
                                                    />
                                                </ButtonGroup>
                                                <AnimeGenreList anime={anime} />
                                            </Item.Extra>
                                        </Item.Content>
                                    </Item>
                                )
                            })
                        }
                    </Item.Group>
            }
        </Container>
    )
}