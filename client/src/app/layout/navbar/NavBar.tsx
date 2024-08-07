import { Menu } from "semantic-ui-react";
import './navbar-styles.css'

export default function NavBar() {
    return (
        <Menu inverted fixed='top'>
            <Menu.Item header className='header'>
                <img className='logo' src='/assets/logo.png' alt='logo' />
                Anime Wiki
            </Menu.Item>
            <Menu.Menu>
                <Menu.Item name='Animes' />
                <Menu.Item name='Genres' />
            </Menu.Menu>
        </Menu>
    )
}