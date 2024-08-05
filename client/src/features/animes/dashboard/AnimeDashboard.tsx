import { useEffect, useState } from "react";
import { Grid, List } from "semantic-ui-react";
import { Anime } from "../../../app/models/anime";
import axios from "axios";

export default function AnimeDashboard() {
    const [animes, setAnimes] = useState<Anime[]>([])

    useEffect(() => {
        axios.get<Anime[]>('http://localhost:5000/api/animes')
            .then(response => setAnimes(response.data))
    }, [])

    return (
        <Grid>
            <Grid.Column width='10'>
                <List>
                    {animes.map(anime => <List.Item key={anime.id}>{anime.title}</List.Item>)}
                </List>
            </Grid.Column>
        </Grid>
    )
}