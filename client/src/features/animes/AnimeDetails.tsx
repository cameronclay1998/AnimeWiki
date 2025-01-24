import { Image, Button, Grid } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { blankAnime } from "../../app/models/anime";
import './animes.css';
import { useNavigate } from "react-router-dom";
import AnimeDetailsMenu from "./anime-details/AnimeDetailsMenu";

export default observer(function AnimeDetails() {
    const navigate = useNavigate();

    const { animeStore } = useStore();
    const { selectedAnime, setSelectedAnime } = animeStore;

    const returnToList = () => {
        setSelectedAnime(blankAnime);
        navigate('/animes')
    }

    return (
        <Grid>
            <Grid.Row>
                <Button content='Back' onClick={returnToList} />
            </Grid.Row>
            <Grid.Row>
                <Grid.Column floated='left' width={6}>
                    <Image src={selectedAnime.photos?.find(p => p.isMain)?.url || '/assets/default-anime.png'} size='medium' />
                </Grid.Column>
                <Grid.Column floated="right" width={10}>
                    <AnimeDetailsMenu />
                </Grid.Column>
            </Grid.Row>
        </Grid>
    )
})