import axios from "axios";
import { useEffect, useState } from "react"
import { Menu } from "semantic-ui-react";

export default function GenreMenu() {
    const [genres, setGenres] = useState<Genre[]>([]);

    useEffect(() => {
        axios.get('https://api.jikan.moe/v4/genres/manga?filter=genres')
            .then(res => setGenres(res.data.data))
            .catch(err => console.log(err))
    }, []);

    return (
        <Menu vertical floated='right'>
            {genres.map(g => <Menu.Item>{g.name}</Menu.Item>)}
        </Menu>
    )
}

interface Genre {
    name: string
}