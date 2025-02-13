import { Container, Item } from "semantic-ui-react"
import './anime-list.css'
import { observer } from "mobx-react-lite"
import { useStore } from "../../../app/stores/store"
import AnimeListItem from "./AnimeListItem"
import { useEffect, useState } from "react"

export default observer(function AnimeList() {
    const { animeStore } = useStore();
    const { animes, fetchAnimes } = animeStore;

    const [loading, setLoading] = useState(false);

    useEffect(() => {
        const handleAsync = async () => {
            setLoading(true);
            await fetchAnimes();
            setLoading(false);
        }
        handleAsync();
    }, [])

    return (
        <Container className='dark-theme'>
            {
                loading
                    ? <div>Loading...</div>
                    : (
                        animes.length < 1
                            ? <div>No Content.</div>
                            : (
                                <Item.Group>
                                    {animes.map(anime => <AnimeListItem anime={anime} />)}
                                </Item.Group>
                            )
                    )
            }
        </Container>
    )
})