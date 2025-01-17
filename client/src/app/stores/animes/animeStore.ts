import { makeAutoObservable } from "mobx";
import { Anime, blankAnime } from "../../models/anime";
import agent from "../../api/agent";

export default class AnimeStore {
    animes: Anime[] = [];
    selectedAnime: Anime = blankAnime;
    editing: boolean = false;
    
    constructor() {
        makeAutoObservable(this)
    }

    toggleEditing = () => {
        this.editing = !this.editing;
    }

    setSelectedAnime = (anime: Anime) => {
        this.selectedAnime = anime;
    }

    fetchAnimes = async () => {
        const animes = await agent.Animes.list();
        this.animes = animes;
    }

    createAnime = async () => {
        const newAnime = await agent.Animes.create(this.selectedAnime);
        this.animes.push(newAnime);
        this.selectedAnime = newAnime;
        this.editing = false;
    }

    updateAnime = async () => {
        try {
            const updatedAnime = await agent.Animes.edit(this.selectedAnime);
            const id = updatedAnime.id;
            const index = this.animes.findIndex(a => a.id === id);
            if (index === -1) {
                throw new Error(`Anime with id: ${id} was not found.`);
            }
            this.animes[index] = updatedAnime;
            this.selectedAnime = updatedAnime;
            this.editing = false;
        } catch (error: any) {
            console.log(error.message);
        }
    }

    deleteAnime = async (id: string) => {
        await agent.Animes.delete(id);
        this.animes = this.animes.filter(a => a.id !== id);
    }
}