import { Button, Container, Grid, Menu } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import MangaList from "./MangaList";

const MangaDashboard = () => {
    const {accountStore} = useStore();
    const {isAdmin} = accountStore;
    
    return (
        <Container fluid>
            <Grid>
                <Grid.Column>
                    <Menu inverted>
                        <Menu.Item header>
                            <h3>Manga</h3>
                        </Menu.Item>
                        {isAdmin && (
                            <Menu.Item position='right'>
                                <Button
                                    // onClick={() => { toggleEditing() }}
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
                    <MangaList />
                </Grid.Column>
            </Grid>
        </Container>
    )
}

export default MangaDashboard;