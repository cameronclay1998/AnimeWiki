import { Button, Item, Label, List, Segment } from "semantic-ui-react"
import { Anime } from "../../../app/models/anime"
import './anime-list.css'

interface Props {
    animes: Anime[]
    handleSelectAnime: (id: string) => void
}

export default function AnimeList({ animes, handleSelectAnime }: Props) {
    return (
        <Segment className='dark-theme'>
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
                                            onClick={() => {handleSelectAnime(anime.id)}}
                                            floated='right'
                                            inverted
                                            content='View'
                                            color='purple'
                                        />
                                        <List className='anime-genre-list' horizontal>
                                            {anime.genres.map(genre => {
                                                return (
                                                    <List.Item key={genre}>
                                                        <Label basic content={genre} />
                                                    </List.Item>
                                                )
                                            })}
                                        </List>
                                    </Item.Extra>
                                </Item.Content>
                            </Item>
                        )
                    })
                }
            </Item.Group>
        </Segment>
    )
}