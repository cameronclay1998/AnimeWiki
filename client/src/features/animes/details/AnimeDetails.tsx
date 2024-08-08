import { Card, CardContent, CardHeader, CardMeta, CardDescription, Image, Button, Icon } from "semantic-ui-react";
import { Anime } from "../../../app/models/anime";
import './anime-details.css'

interface Props {
    selectedAnime: Anime
    handleCancelSelectAnime: () => void
    handleFormOpen: (id: string) => void
}

export default function AnimeDetails({ selectedAnime, handleCancelSelectAnime, handleFormOpen } : Props) {
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
                    <Button onClick={() => handleFormOpen(selectedAnime.id)} inverted color='purple' content='Edit' />
                    <Button onClick={handleCancelSelectAnime} basic inverted color='grey' content='Cancel' />
                </Button.Group>
            </CardContent>
        </Card>
    )
}