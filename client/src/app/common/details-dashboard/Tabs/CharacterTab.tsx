import { observer } from "mobx-react-lite";
import { useStore } from "../../../stores/store";
import { useEffect, useState } from "react";
import agent, { CharacterInfo } from "../../../api/agent";
import { Card, CardMeta, Grid, GridColumn, Image, Placeholder, PlaceholderImage, PlaceholderLine } from "semantic-ui-react";

const CharactersTab = observer(() => {
    const { mangaStore } = useStore();
    const { selectedManga } = mangaStore;

    const [characters, setCharacters] = useState<CharacterInfo[]>([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        if (!selectedManga) return;

        setLoading(true);
        agent.Jikan.mangaCharacters(selectedManga.id).then(res => {
            setCharacters(res.data);
            setLoading(false);
        }).catch(error => {
            console.log(error);
            setLoading(false);
        })
    }, []);

    return (
        <Grid>
            {loading
                ? <Placeholders />
                : characters.map(c => (
                    <GridColumn width={4}>
                        <CharacterCard characterInfo={c} />
                    </GridColumn>
                ))}
        </Grid>
    );
})

const Placeholders = () => {
    const placeholders = [];
    
    for (let i = 0; i < 50; i++) {
        placeholders.push(
            <GridColumn width={4}>
                <Placeholder inverted style={{ height: 200, width: 150, margin: '0px' }}>
                    <PlaceholderImage />
                </Placeholder>
                <Placeholder style={{ margin: '0px' }} inverted>
                    <PlaceholderLine />
                    <PlaceholderLine />
                </Placeholder>
            </GridColumn>
        );
    }

    return placeholders;
}

interface CharacterCardProps {
    characterInfo: CharacterInfo
}

const CharacterCard = ({ characterInfo }: CharacterCardProps) => {
    const { character } = characterInfo;
    return (
        <Card fluid className='dark-theme' style={{ color: 'white' }}>
            <Image size='small' src={character.images.jpg.image_url} />
            {character.name}
            <CardMeta>{characterInfo.role}</CardMeta>
        </Card>
    )
}

export default CharactersTab;