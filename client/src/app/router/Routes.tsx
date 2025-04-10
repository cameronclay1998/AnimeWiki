import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../layout/App";
import HomePage from "../../features/home/HomePage";
import AnimeDashboard from "../../features/animes/AnimeDashboard";
import AnimeDetails from "../../features/animes/anime-details/AnimeDetails";
import MangaDashboard from "../../features/manga/MangaDashboard";
import ShopDashboard from "../../features/shop/ShopDashboard";
import MangaDetails from "../../features/manga/MangaDetails";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            {path: '', element: <HomePage />},
            {path: 'animes', element: <AnimeDashboard />},
            {path: 'anime-details', element: <AnimeDetails />},
            {path: 'manga', element: <MangaDashboard />},
            {path: 'manga-details', element: <MangaDetails />},
            {path: 'shop', element: <ShopDashboard />}
        ]
    }
]

export const router = createBrowserRouter(routes)