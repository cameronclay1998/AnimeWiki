import { Menu } from "semantic-ui-react";
import './navbar-styles.css'
import { NavLink } from "react-router-dom";

export default function NavBar() {
    return (
        <Menu inverted fixed='top'>
            <Menu.Item as={NavLink} to='/' header style={{paddingRight: '100px'}}>
                <img className='logo' src='/assets/logo.png' alt='logo' />
                Anime Wiki
            </Menu.Item>
            <Menu.Menu>
                <Menu.Item as={NavLink} to='/animes' name='Animes' />
                <Menu.Item as={NavLink} to='/manga' name='Manga' />
                <Menu.Item as={NavLink} to='/shop' name='Shop' />
            </Menu.Menu>
        </Menu>
    )
}