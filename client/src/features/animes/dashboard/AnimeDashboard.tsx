import { useEffect, useState } from "react";
import { Button, Container, Grid, Menu } from "semantic-ui-react";
import { Anime } from "../../../app/models/anime";
import axios from "axios";
import AnimeList from "./AnimeList";
import AnimeDetails from "../details/AnimeDetails";
import ActivityForm from "../form/ActivityForm";

export default function AnimeDashboard() {
    const [animes, setAnimes] = useState<Anime[]>([])
    const [selectedAnime, setSelectedAnime] = useState<Anime | undefined>(undefined);
    const [editMode, setEditMode] = useState(false);

    useEffect(() => {
        axios.get<Anime[]>('http://localhost:5000/api/animes')
            .then(response => setAnimes(response.data))
    }, [])

    const handleSelectAnime = (id: string) => {
        setSelectedAnime(animes.find(a => a.id == id))
    }

    const handleCancelSelectAnime = () => {
        setSelectedAnime(undefined)
    }

    const handleFormOpen = (id?: string) => {
        id ? handleSelectAnime(id) : handleCancelSelectAnime()
        setEditMode(true)
    }

    const handleFormClose = () => {
        setEditMode(false)
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
                    />
                </Grid.Column>
                <Grid.Column width='6'>
                    {
                        selectedAnime && !editMode &&
                        <AnimeDetails
                            selectedAnime={selectedAnime}
                            handleCancelSelectAnime={handleCancelSelectAnime}
                            handleFormOpen={handleFormOpen}
                        />
                    }
                    {
                        editMode &&
                        <ActivityForm
                            selectedAnime={selectedAnime}
                            handleCancelSelectAnime={handleCancelSelectAnime}
                            handleFormClose={handleFormClose}
                        />
                    }
                </Grid.Column>
            </Grid>
        </Container>
    )
}