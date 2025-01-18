import { Button, ButtonGroup, Item } from "semantic-ui-react";
import AnimeGenreList from "../AnimeGenreList";
import { Anime } from "../../../app/models/anime";
import { useStore } from "../../../app/stores/store";
import { useNavigate } from "react-router-dom";

interface Props {
    anime: Anime
}

const AnimeListItem = ({ anime }: Props) => {
    const navigate = useNavigate();

    const { animeStore, accountStore } = useStore();
    const { isAdmin } = accountStore;
    const { deleteAnime, setSelectedAnime } = animeStore;

    const openAnimeDetails = () => {
        setSelectedAnime(anime);
        navigate('/anime-details')
    }

    return (
        <Item className='anime-item' key={anime.id} onClick={openAnimeDetails}>
            <Item.Image src={anime.photos?.find(p => p.isMain)?.url || '/assets/default-anime.png'} />
            <Item.Content>
                <Item.Header as='a'>{anime.title}</Item.Header>
                <Item.Meta>{anime.releaseDate}</Item.Meta>
                <Item.Description>{anime.description}</Item.Description>
                <Item.Extra>
                    <AnimeGenreList anime={anime} />
                    {isAdmin && (
                        <ButtonGroup style={{ marginTop: '30px' }} floated="right">
                            <Button
                                onClick={() => { deleteAnime(anime.id) }}
                                floated='right'
                                inverted
                                content='Delete'
                                color='red'
                            />
                            <Button
                                onClick={openAnimeDetails}
                                floated='right'
                                inverted
                                content='View'
                                color='purple'
                            />
                        </ButtonGroup>
                    )}
                </Item.Extra>
            </Item.Content>
        </Item>
    )
}

export default AnimeListItem;