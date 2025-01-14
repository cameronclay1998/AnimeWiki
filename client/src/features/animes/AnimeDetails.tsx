import { Card, CardContent, CardHeader, CardMeta, CardDescription, Image, Button } from "semantic-ui-react";
import './anime-details.css'
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { blankAnime } from "../../app/models/anime";

export default observer(function AnimeDetails() {
    const {animeStore} = useStore();
    const {selectedAnime, toggleEditing, setSelectedAnime} = animeStore;

    // if (!selectedAnime) return <p>No Anime selected.</p>

    return (
        <Card fluid className='dark-theme'>
            <Image src='/assets/default-anime.png' />
            <CardContent>
                <CardHeader>{selectedAnime.title}</CardHeader>
                <CardMeta>
                    <span>{selectedAnime.releaseDate}</span>
                </CardMeta>
                <CardDescription>
                    {selectedAnime.description}
                </CardDescription>
            </CardContent>
            <CardContent extra>
                <Button.Group width='2'>
                    <Button onClick={() => {toggleEditing()}} inverted color='purple' content='Edit' />
                    <Button onClick={() => {setSelectedAnime(blankAnime)}} basic inverted color='grey' content='Cancel' />
                </Button.Group>
            </CardContent>
        </Card>
    )
})