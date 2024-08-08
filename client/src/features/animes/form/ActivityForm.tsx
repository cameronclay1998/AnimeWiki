import { Button, Form, Segment } from "semantic-ui-react";
import { Anime } from "../../../app/models/anime";

interface Props {
    selectedAnime: Anime | undefined
    handleCancelSelectAnime: () => void
    handleFormClose: () => void
}

export default function ActivityForm({ handleFormClose } : Props) {
    return (
        <Segment clearing className='dark-theme'>
            <h3>Edit/Create</h3>
            <Form>
                <Form.Input placeholder='Title' />
                <Form.Input placeholder='Release Date' />
                <Form.TextArea placeholder='Description' />
                <Form.Input placeholder='Author First Name' />
                <Form.Input placeholder='Author Last Name' />
                <Form.Input placeholder='Genres' />
                <Button floated='right' type='submit' content='Submit' inverted color='purple'/>
                <Button onClick={handleFormClose} floated='right' type='button' content='Cancel' inverted color='grey' />
            </Form>
        </Segment>
    )
}