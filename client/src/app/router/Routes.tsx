import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../layout/App";
import HomePage from "../../features/home/HomePage";
import AnimeDashboard from "../../features/animes/AnimeDashboard";
import AnimeDetails from "../../features/animes/AnimeDetails";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            {path: '', element: <HomePage />},
            {path: 'animes', element: <AnimeDashboard />},
            {path: 'anime-details', element: <AnimeDetails />}
        ]
    }
]

export const router = createBrowserRouter(routes)