import { Button, ButtonGroup, Container, Item } from "semantic-ui-react"
import './anime-list.css'
import AnimeGenreList from "./AnimeGenreList"
import { observer } from "mobx-react-lite"
import { useStore } from "../../app/stores/store"
import { useNavigate } from "react-router-dom"

export default observer(function AnimeList() {
    const { animeStore } = useStore();
    const { animes, setSelectedAnime, deleteAnime } = animeStore;

    const navigate = useNavigate();

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
                                        <Item.Image src={anime.photos?.find(p => p.isMain)?.url || '/assets/default-anime.png'} />
                                        <Item.Content>
                                            <Item.Header as='a'>{anime.title}</Item.Header>
                                            <Item.Meta>{anime.releaseDate}</Item.Meta>
                                            <Item.Description>{anime.description}</Item.Description>
                                            <Item.Extra>
                                            <AnimeGenreList anime={anime} />
                                                <ButtonGroup style={{marginTop: '30px'}} floated="right">
                                                    <Button
                                                        onClick={() => { deleteAnime(anime.id) }}
                                                        floated='right'
                                                        inverted
                                                        content='Delete'
                                                        color='red'
                                                    />
                                                    <Button
                                                        onClick={() => { 
                                                            setSelectedAnime(anime);
                                                            navigate('/anime-details')
                                                         }}
                                                        floated='right'
                                                        inverted
                                                        content='View'
                                                        color='purple'
                                                    />
                                                </ButtonGroup>
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
})