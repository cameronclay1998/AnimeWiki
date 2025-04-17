import { useState } from "react";
import { Container, Input, Menu, MenuItem, MenuMenu } from "semantic-ui-react";
import AboutTab from "./Tabs/AboutTab";
import CharactersTab from "./Tabs/CharacterTab";
import NotImplemented from "../NotImplemented";

const ABOUT_TAB = 'About';
const CHARACTERS_TAB = "Characters";

export default function DetailsMenu() {
    const [activeItem, setActiveItem] = useState(ABOUT_TAB);
    const handleItemClick = (name: string) => setActiveItem(name);

    return (
        <>
            <Menu attached='top' tabular>
                <MenuItem
                    name={ABOUT_TAB}
                    active={activeItem === ABOUT_TAB}
                    onClick={() => {handleItemClick(ABOUT_TAB)}}
                />
                <MenuItem
                    name={CHARACTERS_TAB}
                    active={activeItem === CHARACTERS_TAB}
                    onClick={() => {handleItemClick(CHARACTERS_TAB)}}
                />
                <MenuMenu position='right'>
                    <MenuItem>
                        <Input
                            transparent
                            icon={{ name: 'search', link: true }}
                            placeholder='Search users...'
                        />
                    </MenuItem>
                </MenuMenu>
            </Menu>

            <Container
                attached='bottom'
                style={{
                    borderBottom: 'solid white 1px',
                    borderLeft: 'solid white 1px',
                    borderRight: 'solid white 1px',
                    padding: '15px',
                    height: '500px',
                    overflowY: 'auto'
                }}
            >
                <ActiveTab tabName={activeItem} />
            </Container>
        </>
    )
}

interface TabProps {
    tabName: string
}

const ActiveTab = ({ tabName }: TabProps) => {
    switch (tabName) {
        case ABOUT_TAB:
            return <AboutTab />
        case CHARACTERS_TAB:
            return <CharactersTab />
        default:
            return <NotImplemented />
    }
}