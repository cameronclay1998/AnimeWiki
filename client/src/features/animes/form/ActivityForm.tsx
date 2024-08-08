import { Button, Form, List, Menu, Segment } from "semantic-ui-react";
import { Anime } from "../../../app/models/anime";
import AnimeGenreList from "../dashboard/AnimeGenreList";
import { useEffect, useState } from "react";
import { Genre } from "../../../app/models/genre";
import axios from "axios";

interface Props {
    selectedAnime: Anime
    handleCancelSelectAnime: () => void
    handleFormClose: () => void
}

export default function ActivityForm({ handleFormClose, selectedAnime }: Props) {
    const [genres, setGenres] = useState<Genre[]>([]);

    useEffect(() => {
        axios.get<Genre[]>('http://localhost:5000/api/genres')
            .then(response => setGenres(response.data))
    }, [])

    return (
        <Segment clearing className='dark-theme'>
            <h3>Edit/Create</h3>
            <Form>
                <Form.Input placeholder='Title' value={selectedAnime.title} />
                <Form.Input placeholder='Release Date' value={selectedAnime.releaseDate} />
                <Form.TextArea placeholder='Description' value={selectedAnime.description} />
                <Form.Input placeholder='Author First Name' value={selectedAnime.authorFirstName} />
                <Form.Input placeholder='Author Last Name' value={selectedAnime.authorLastName} />
                <AnimeGenreList anime={selectedAnime} />
                <Button color='purple' inverted>Add Genre</Button>
                <Form.Select
                    style={{ border: 'solid 1px #ffffffe6', marginTop: '10px' }}
                    options={genres.map(genre => ({ key: genre.id, text: genre.name, value: genre.name }))}
                />
                <Button.Group floated="right" style={{ marginTop: '20px' }}>
                    <Button type='submit' content='Submit' inverted color='purple' />
                    <Button onClick={handleFormClose} floated='right' type='button' content='Cancel' inverted color='grey' />
                </Button.Group>
            </Form>
        </Segment>
    )
}