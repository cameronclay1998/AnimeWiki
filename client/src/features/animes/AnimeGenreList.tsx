import { List } from "semantic-ui-react"
import { observer } from "mobx-react-lite"
import { useStore } from "../../app/stores/store"

export default observer(function AnimeGenreList() {
    const {animeStore} = useStore();
    const {selectedAnime} = animeStore;

    return (
        <List className='anime-genre-list' horizontal>
            {selectedAnime.genres.map(genre => {
                return (
                    <List.Item key={genre}>
                        <List.Content><p>{genre}</p></List.Content>
                    </List.Item>
                )
            })}
        </List>
    )
})