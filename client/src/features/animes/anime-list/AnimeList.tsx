import './anime-list.css'
import { observer } from "mobx-react-lite"
import { useStore } from "../../../app/stores/store"
import { useEffect, useState } from "react"
import ListBox from "../../../app/common/listbox/ListBox"
import { useNavigate } from "react-router-dom"

export default observer(function AnimeList() {
    const { animeStore, accountStore } = useStore();
    const { animes, fetchAnimes, setSelectedAnime, deleteAnime } = animeStore;
    const { isAdmin } = accountStore;

    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {
        const handleAsync = async () => {
            setLoading(true);
            await fetchAnimes();
            setLoading(false);
        }
        handleAsync();
    }, [])

    const openDetails = (id: string) => {
        const anime = animes.find(a => a.id === id);

        if (!anime) return;

        setSelectedAnime(anime);
        navigate('/anime-details')
    }

    return (
        <ListBox
            loading={loading}
            data={animes.map(anime => ({
                id: anime.id,
                photoUrl: anime.photos?.find(p => p.isMain)?.url || '',
                title: anime.title,
                releaseDate: anime.releaseDate,
                description: anime.description
            }))}
            isAdmin={isAdmin}
            openDetails={openDetails}
            deleteItem={deleteAnime}
        />
    )
})