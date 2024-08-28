import { Button, Grid, Form, Segment } from "semantic-ui-react";
import { Anime } from "../../../app/models/anime";
import AnimeGenreList from "../dashboard/AnimeGenreList";
import { ChangeEvent, useEffect, useState } from "react";
import { Genre } from "../../../app/models/genre";
import axios from "axios";

interface Props {
    selectedAnime: Anime
    handleCancelSelectAnime: () => void
    handleFormClose: () => void
    setSelectedAnime: (newAnime: Anime) => void,
    handleSubmit: () => void
}

export default function AnimeForm({ 
    handleFormClose, 
    selectedAnime, 
    setSelectedAnime, 
    handleSubmit
}: Props) {
    const [genres, setGenres] = useState<Genre[]>([]);
    const [selectedGenre, setSelectedGenre] = useState('');

    useEffect(() => {
        axios.get<Genre[]>('http://localhost:5000/api/genres')
            .then(response => {
                setGenres(response.data)
                setSelectedGenre(response.data[0].name)
            })
    }, [])

    const addGenreClick = () => {
        if (selectedAnime.genres.includes(selectedGenre)) return;
        setSelectedAnime({...selectedAnime, genres: [...selectedAnime.genres, selectedGenre]})
    }

    const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setSelectedAnime({ ...selectedAnime, [name]: value });
    }

    return (
        <Segment clearing className='dark-theme'>
            <h3>Edit/Create</h3>
            <Form>
                <Form.Input placeholder='Title' value={selectedAnime.title} name='title' onChange={handleChange} />
                <Form.Input type='date' placeholder='Release Date' value={selectedAnime.releaseDate} name='releaseDate' onChange={handleChange} />
                <Form.TextArea placeholder='Description' value={selectedAnime.description} name='description' onChange={handleChange} />
                <Form.Input placeholder='Author First Name' value={selectedAnime.authorFirstName} name='authorFirstName' onChange={handleChange} />
                <Form.Input placeholder='Author Last Name' value={selectedAnime.authorLastName} name='authorLastName' onChange={handleChange} />
                <AnimeGenreList anime={selectedAnime} />
                <Grid className='genre-selector-grid'>
                    <Grid.Column width='10' className='genre-selector-column'>
                        <Form.Select
                            value={selectedGenre}
                            onChange={(_e, data: any) => { setSelectedGenre(data.value) }}
                            style={{ border: 'solid 1px #ffffffe6' }}
                            options={genres.map(genre => ({ key: genre.id, text: genre.name, value: genre.name }))}
                        />
                    </Grid.Column>
                    <Grid.Column width='6' className='genre-selector-column'>
                        <Button onClick={addGenreClick} color='purple' inverted>Add Genre</Button>
                    </Grid.Column>
                </Grid>
                <Button.Group floated="left" style={{ marginTop: '20px' }}>
                    <Button onClick={handleSubmit} type='submit' content='Submit' inverted color='purple' />
                    <Button onClick={handleFormClose} floated='right' type='button' content='Cancel' inverted color='grey' />
                </Button.Group>
            </Form>
        </Segment>
    )
}