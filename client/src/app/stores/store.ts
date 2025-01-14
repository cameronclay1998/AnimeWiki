import { createContext, useContext } from "react";
import AnimeUiStore from "./animes/animeUiStore";
import AnimeStore from "./animes/animeStore";

interface Store {
    animeStore: AnimeStore,
    animeUiStore: AnimeUiStore
}

export const store: Store = {
    animeStore: new AnimeStore(),
    animeUiStore: new AnimeUiStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}