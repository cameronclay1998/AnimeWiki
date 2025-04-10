import { makeAutoObservable } from "mobx";
import Manga from '../../app/models/manga';
import agent from "../api/agent";

export default class MangaStore {
    mangas: Manga[] = [];
    selectedManga: Manga | undefined = undefined;

    constructor() {
        makeAutoObservable(this);
    }

    fetchManga = async () => {
        this.mangas = await agent.Mangas.list();
    }

    deleteManga = () => {
        
    }

    setSelectedManga = (manga: Manga) => {
        this.selectedManga = manga;
    }
}