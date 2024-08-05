import { Button, Menu } from "semantic-ui-react";
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
                <Menu.Item name='Menu Item 2' />
                <Menu.Item name='Menu Item 3' />
            </Menu.Menu>
            <Menu.Item position='right'>
                <Button content='Create Anime' color='purple' />
            </Menu.Item>
        </Menu>
    )
}