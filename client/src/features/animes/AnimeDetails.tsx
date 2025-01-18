import { Card, CardContent, CardHeader, CardMeta, CardDescription, Image, Button, Grid, Menu, Input, Segment, MenuItemProps } from "semantic-ui-react";
import { observer } from "mobx-react-lite";
import { useStore } from "../../app/stores/store";
import { blankAnime } from "../../app/models/anime";
import './animes.css';
import { useNavigate } from "react-router-dom";
import { useState, MouseEvent } from "react";

export default observer(function AnimeDetails() {
    const navigate = useNavigate();

    const { animeStore, accountStore } = useStore();
    const { selectedAnime, toggleEditing, setSelectedAnime } = animeStore;
    const { isAdmin } = accountStore;

    const returnToList = () => {
        setSelectedAnime(blankAnime);
        navigate('/animes')
    }

    const [activeIndex, setActiveIndex] = useState('0');
    const handleItemClick = (_e: MouseEvent<HTMLAnchorElement>, data: MenuItemProps) => {
        if (data.name) setActiveIndex(data.name);
    }

    return (
        <div>
            <Menu attached='top' tabular>
                <Menu.Item
                    name='0'
                    active={activeIndex === '0'}
                    onClick={handleItemClick}
                >Hello 0</Menu.Item>
                <Menu.Item
                    name='1'
                    active={activeIndex === '1'}
                    onClick={handleItemClick}
                >Hello 1</Menu.Item>
                <Menu.Item
                    name='2'
                    active={activeIndex === '2'}
                    onClick={handleItemClick}
                >Hello 2</Menu.Item>
                <Menu.Item
                    name='3'
                    active={activeIndex === '3'}
                    onClick={handleItemClick}
                >Hello 3</Menu.Item>
                <Menu.Menu position='right'>
                    <Menu.Item>
                        <Input
                            transparent
                            icon={{ name: 'search', link: true }}
                            placeholder='Search users...'
                        />
                    </Menu.Item>
                </Menu.Menu>
            </Menu>

            <Segment attached='bottom'>
                <img src='/images/wireframe/paragraph.png' />
            </Segment>
        </div>
    )

    return (
        <Grid>
            <Grid.Row>
                <Button content='Back' onClick={returnToList} />
            </Grid.Row>
            <Grid.Row>
                <Grid.Column floated='left' width={8}>
                    <Image src={selectedAnime.photos?.find(p => p.isMain)?.url || '/assets/default-anime.png'} />
                </Grid.Column>
                <Grid.Column floated='right' width={8}>
                    <Card className='dark-theme'>
                        <CardContent>
                            <CardHeader>{selectedAnime.title}</CardHeader>
                            <CardMeta>
                                <span>{selectedAnime.releaseDate}</span>
                            </CardMeta>
                            <CardDescription>
                                {selectedAnime.description}
                            </CardDescription>
                        </CardContent>
                        {isAdmin && (
                            <CardContent extra>
                                <Button.Group width='2'>
                                    <Button onClick={() => { toggleEditing() }} inverted color='purple' content='Edit' />
                                    <Button onClick={() => { setSelectedAnime(blankAnime) }} basic inverted color='grey' content='Cancel' />
                                </Button.Group>
                            </CardContent>
                        )}
                    </Card>
                </Grid.Column>
            </Grid.Row>
        </Grid>
    )
})