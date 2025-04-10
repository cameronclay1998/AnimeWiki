import { observer } from "mobx-react-lite"
import { useEffect, useState } from "react"
import { useStore } from '../../app/stores/store'
import ListBox from '../../app/common/listbox/ListBox'
import { useNavigate } from "react-router-dom"

export default observer(function MangaList() {
    const { accountStore, mangaStore } = useStore();
    const { isAdmin } = accountStore;
    const { mangas, fetchManga, deleteManga, setSelectedManga } = mangaStore;

    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {
        const handleAsync = async () => {
            try {
                setLoading(true);
                await fetchManga();
            }
            catch (error) {
                console.log(error);
            }
            finally {
                setLoading(false);
            }
        }
        handleAsync();
    }, [])

    const openDetails = (id: string) => {
        console.log(id)
        const manga = mangas.find(m => m.id === id);

        if (!manga) return;

        setSelectedManga(manga);
        navigate('/manga-details')
    }

    return (
        <ListBox
            loading={loading}
            data={mangas.map(manga => ({
                id: manga.id,
                photoUrl: manga.photos?.find(p => p.isMain)?.url || '',
                title: manga.title,
                releaseDate: manga.published,
                description: manga.description
            }))}
            isAdmin={isAdmin}
            openDetails={openDetails}
            deleteItem={deleteManga}
        />
    )
})