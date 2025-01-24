import { observer } from "mobx-react-lite"
import { useStore } from "../../../../app/stores/store"
import { Button, Card } from "semantic-ui-react";
import { blankAnime } from "../../../../app/models/anime";

const About = () => {
    const { animeStore, accountStore } = useStore();
    const { selectedAnime, toggleEditing, setSelectedAnime } = animeStore;
    const { isAdmin } = accountStore;
    return (
        <>
            <Card className='dark-theme'>
                <Card.Content>
                    <Card.Header>{selectedAnime.title}</Card.Header>
                    <Card.Meta>
                        <span>{selectedAnime.releaseDate}</span>
                    </Card.Meta>
                    <Card.Description>
                        {selectedAnime.description}
                    </Card.Description>
                </Card.Content>
                {isAdmin && (
                    <Card.Content extra>
                        <Button.Group width='2'>
                            <Button onClick={() => { toggleEditing() }} inverted color='purple' content='Edit' />
                            <Button onClick={() => { setSelectedAnime(blankAnime) }} basic inverted color='grey' content='Cancel' />
                        </Button.Group>
                    </Card.Content>
                )}
            </Card>
        </>
    )
}

export default observer(About);