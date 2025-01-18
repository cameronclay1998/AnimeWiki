import { createContext, useContext } from "react";
import AnimeUiStore from "./animes/animeUiStore";
import AnimeStore from "./animes/animeStore";
import AccountStore from "./accountStore";

interface Store {
    animeStore: AnimeStore,
    animeUiStore: AnimeUiStore,
    accountStore: AccountStore
}

export const store: Store = {
    animeStore: new AnimeStore(),
    animeUiStore: new AnimeUiStore(),
    accountStore: new AccountStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}