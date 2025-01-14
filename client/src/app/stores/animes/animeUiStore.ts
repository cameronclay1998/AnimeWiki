import { makeAutoObservable } from "mobx";
import { blankAnime } from "../../models/anime";

const parseDate = (date: string) => {
    let index = date.indexOf('T');
    return date.substring(0, index);
}

export default class AnimeUiStore {
    editing: boolean = false;

    constructor() {
        makeAutoObservable(this);
    }

    openAnimeForm = () => {
        this.editing = true;
    }

    handleSelectAnime = (id: string) => {
        let anime = this.animes.find(a => a.id == id)
        if (!anime) return;
        this.setSelectedAnime({...anime, releaseDate: parseDate(anime.releaseDate)})
        setViewMode(true);
    }

    handleDeleteAnime = (id: string) => {
        agent.Animes.delete(id).then(() => {
            this.setAnimes(this.animes.filter(x => x.id !== id))
        })
    }

    closeAnimeDetails = () => {
        this.setSelectedAnime(blankAnime)
        setViewMode(false)
    }

    openAnimeForm = (id?: string) => {
        id ? this.handleSelectAnime(id) : this.handleCancelSelectAnime()
        setEditMode(true)
        setViewMode(false)
    }

    handleFormClose = () => {
        setEditMode(false)
        setViewMode(true)
    }
}