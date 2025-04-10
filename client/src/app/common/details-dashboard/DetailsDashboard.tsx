import { useEffect, useState } from "react";
import { 
    Button, 
    Card, 
    CardContent, 
    CardDescription, 
    CardHeader, 
    CardMeta, 
    Container, 
    Grid, 
    GridColumn, 
    GridRow, 
    Icon, 
    Image, 
    Input, 
    Menu, 
    MenuItem, 
    MenuMenu 
} from "semantic-ui-react";
import NotImplemented from "../NotImplemented";
import { useNavigate } from "react-router-dom";
import { observer } from "mobx-react-lite";
import { useStore } from "../../stores/store";
import agent, { CharacterInfo } from "../../api/agent";

const ABOUT_TAB = 'About';
const CHARACTERS_TAB = "Characters";

export default observer(function DetailsDashboard() {
    const {mangaStore} = useStore();
    const {selectedManga} = mangaStore;

    const navigate = useNavigate();

    return (
        <Container fluid>
            <Button style={{ marginBottom: '10px' }} onClick={() => { navigate('/manga') }}>Back</Button>
            <Grid>
                <GridColumn width={6}>
                    <Image src={selectedManga?.photos[0].url} size='large' />
                </GridColumn>
                <GridColumn width={10}>
                    <DetailsMenu />
                </GridColumn>
            </Grid>
        </Container>
    )
})

function DetailsMenu() {
    const [activeItem, setActiveItem] = useState(ABOUT_TAB);
    const handleItemClick = (name: string) => setActiveItem(name);

    return (
        <>
            <Menu attached='top' tabular>
                <MenuItem
                    name={ABOUT_TAB}
                    active={activeItem === ABOUT_TAB}
                    onClick={() => {handleItemClick(ABOUT_TAB)}}
                />
                <MenuItem
                    name={CHARACTERS_TAB}
                    active={activeItem === CHARACTERS_TAB}
                    onClick={() => {handleItemClick(CHARACTERS_TAB)}}
                />
                <MenuMenu position='right'>
                    <MenuItem>
                        <Input
                            transparent
                            icon={{ name: 'search', link: true }}
                            placeholder='Search users...'
                        />
                    </MenuItem>
                </MenuMenu>
            </Menu>

            <Container
                attached='bottom'
                style={{
                    borderBottom: 'solid white 1px',
                    borderLeft: 'solid white 1px',
                    borderRight: 'solid white 1px',
                    padding: '15px',
                    height: '500px',
                    overflowY: 'auto'
                }}
            >
                <ActiveTab tabName={activeItem} />
            </Container>
        </>
    )
}

interface TabProps {
    tabName: string
}

const ActiveTab = ({ tabName }: TabProps) => {
    switch (tabName) {
        case ABOUT_TAB:
            return <AboutTab />
        case CHARACTERS_TAB:
            return <CharactersTab />
        default:
            return <NotImplemented />
    }
}

const AboutTab = observer(() => {
    const {mangaStore} = useStore();
    const {selectedManga} = mangaStore;

    if (!selectedManga) return <p>No Content.</p>
    
    return (
        <Card fluid className='dark-theme'>
            <CardHeader>{selectedManga.title}</CardHeader>
            <CardMeta>{selectedManga.published}</CardMeta>
            <CardDescription>{selectedManga.description}</CardDescription>
        </Card>
    )
})

const CharactersTab = observer(() => {
    const {mangaStore} = useStore();
    const {selectedManga} = mangaStore;

    const [characters, setCharacters] = useState<CharacterInfo[]>([]);

    useEffect(() => {
        if (!selectedManga) return;
        agent.Jikan.mangaCharacters(selectedManga.id).then(res => setCharacters(res.data))
    }, []);

    return (
        characters.map(c => (
            <CharacterCard characterInfo={c} />
        ))
    )
})

interface CharacterCardProps {
    characterInfo: CharacterInfo
}

const CharacterCard = ({characterInfo}: CharacterCardProps) => {
    const {character} = characterInfo;
    return (
        <Card fluid className='dark-theme'>
            <Image size='small' src={character.images.jpg.image_url} />
            <CardHeader>{character.name}</CardHeader>
            <CardMeta>{characterInfo.role}</CardMeta>
            <CardDescription>Unknown</CardDescription>
        </Card>
    )
}