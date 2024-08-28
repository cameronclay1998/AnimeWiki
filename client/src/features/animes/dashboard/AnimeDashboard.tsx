import { useEffect, useState } from "react";
import { Button, Container, Grid, Menu } from "semantic-ui-react";
import { Anime, blankAnime } from "../../../app/models/anime";
import AnimeList from "./AnimeList";
import AnimeDetails from "../details/AnimeDetails";
import AnimeForm from "../form/AnimeForm";
import agent from "../../../app/api/agent";

export default function AnimeDashboard() {
    const [animes, setAnimes] = useState<Anime[]>([])
    const [selectedAnime, setSelectedAnime] = useState<Anime>(blankAnime);
    const [editMode, setEditMode] = useState(false);
    const [viewMode, setViewMode] = useState(false);

    useEffect(() => {
        agent.Animes.list().then(response => setAnimes(response))
    }, [])

    const handleSelectAnime = (id: string) => {
        let anime = animes.find(a => a.id == id)
        if (!anime) return;
        setSelectedAnime({...anime, releaseDate: parseDate(anime.releaseDate)})
        setViewMode(true);
    }

    const parseDate = (date: string) => {
        let index = date.indexOf('T');
        return date.substring(0, index);
    }

    const handleCancelSelectAnime = () => {
        setSelectedAnime(blankAnime)
        setViewMode(false)
    }

    const handleFormOpen = (id?: string) => {
        id ? handleSelectAnime(id) : handleCancelSelectAnime()
        setEditMode(true)
        setViewMode(false)
    }

    const handleFormClose = () => {
        setEditMode(false)
        setViewMode(true)
    }

    const handleDeleteAnime = (id: string) => {
        agent.Animes.delete(id).then(() => {
            setAnimes(animes.filter(x => x.id !== id))
        })
    }

    const handleSubmit = async () => {
        if (!selectedAnime) return

        if (!selectedAnime.id) {
            var newAnime = await agent.Animes.create(selectedAnime)
            setAnimes([...animes, newAnime])
            setSelectedAnime(newAnime)
        }
        else {
            var updatedAnime = await agent.Animes.edit(selectedAnime)
            setAnimes([...animes.filter(x => x.id !== selectedAnime.id), updatedAnime])
            setSelectedAnime(updatedAnime)
        }

        setEditMode(false)
        setViewMode(true)
    }

    return (
        <Container fluid>
            <Grid>
                <Grid.Column width='10'>
                    <Menu inverted>
                        <Menu.Item header>
                            <h3>Animes</h3>
                        </Menu.Item>
                        <Menu.Item position='right'>
                            <Button onClick={() => { handleFormOpen() }} content='Create Anime' inverted color='purple' />
                        </Menu.Item>
                    </Menu>
                </Grid.Column>
            </Grid>
            <Grid>
                <Grid.Column width='10'>
                    <AnimeList
                        animes={animes}
                        handleSelectAnime={handleSelectAnime}
                        handleDeleteAnime={handleDeleteAnime}
                    />
                </Grid.Column>
                <Grid.Column width='6'>
                    {
                        viewMode &&
                        <AnimeDetails
                            selectedAnime={selectedAnime}
                            handleCancelSelectAnime={handleCancelSelectAnime}
                            handleFormOpen={handleFormOpen}
                        />
                    }
                    {
                        editMode &&
                        <AnimeForm
                            selectedAnime={selectedAnime}
                            handleCancelSelectAnime={handleCancelSelectAnime}
                            handleFormClose={handleFormClose}
                            setSelectedAnime={setSelectedAnime}
                            handleSubmit={handleSubmit}
                        />
                    }
                </Grid.Column>
            </Grid>
        </Container>
    )
}