import { useEffect } from "react";
import { Button, Container, Grid, Menu } from "semantic-ui-react";
import AnimeList from "./anime-list/AnimeList";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import './animes.css';

export default observer(function AnimeDashboard() {
    const {animeStore, accountStore} = useStore();
    const {fetchAnimes, toggleEditing} = animeStore;
    const {isAdmin} = accountStore;

    useEffect(() => { fetchAnimes() }, [])

    return (
        <Container fluid>
            <Grid>
                <Grid.Column>
                    <Menu inverted>
                        <Menu.Item header>
                            <h3>Animes</h3>
                        </Menu.Item>
                        {isAdmin && (
                            <Menu.Item position='right'>
                                <Button
                                    onClick={() => { toggleEditing() }}
                                    content='Create Anime'
                                    inverted
                                    color='purple'
                                />
                            </Menu.Item>
                        )}
                    </Menu>
                </Grid.Column>
            </Grid>
            <Grid>
                <Grid.Column className='anime-list-container'>
                    <AnimeList />
                </Grid.Column>
            </Grid>
        </Container>
    )
})