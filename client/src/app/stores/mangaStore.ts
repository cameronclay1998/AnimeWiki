import { makeAutoObservable } from "mobx";
import Manga from '../../app/models/manga';
import agent from "../api/agent";

export default class MangaStore {
    mangas: Manga[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    fetchMangas = async () => {
        this.mangas = await agent.Mangas.list();
    }

    deleteManga = () => {
        
    }
}