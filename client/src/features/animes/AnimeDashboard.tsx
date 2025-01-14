import { useEffect } from "react";
import { Button, Container, Grid, Menu } from "semantic-ui-react";
import AnimeList from "./AnimeList";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import AnimeForm from "./AnimeForm";
import AnimeDetails from "./AnimeDetails";

export default observer(function AnimeDashboard() {
    const {animeStore} = useStore();
    const {fetchAnimes, toggleEditing, editing} = animeStore;

    useEffect(() => {fetchAnimes()}, [])

    return (
        <Container fluid>
            <Grid>
                <Grid.Column width='10'>
                    <Menu inverted>
                        <Menu.Item header>
                            <h3>Animes</h3>
                        </Menu.Item>
                        <Menu.Item position='right'>
                            <Button 
                                onClick={() => {toggleEditing()}} 
                                content='Create Anime' 
                                inverted 
                                color='purple' 
                            />
                        </Menu.Item>
                    </Menu>
                </Grid.Column>
            </Grid>
            <Grid>
                <Grid.Column width='10'>
                    <AnimeList />
                </Grid.Column>
                <Grid.Column width='6'>
                    {editing ? <AnimeForm /> : <AnimeDetails />}
                </Grid.Column>
            </Grid>
        </Container>
    )
})