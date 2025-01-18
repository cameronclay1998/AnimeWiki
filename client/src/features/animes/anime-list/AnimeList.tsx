import { Container, Item } from "semantic-ui-react"
import './anime-list.css'
import { observer } from "mobx-react-lite"
import { useStore } from "../../../app/stores/store"
import AnimeListItem from "./AnimeListItem"

export default observer(function AnimeList() {
    const { animeStore } = useStore();
    const { animes } = animeStore;

    return (
        <Container className='dark-theme'>
            {
                animes.length < 1 ?
                    <div>No Content</div> :
                    <Item.Group>
                        {animes.map(anime => <AnimeListItem anime={anime} />)}
                    </Item.Group>
            }
        </Container>
    )
})