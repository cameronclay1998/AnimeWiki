import { useState, MouseEvent } from "react";
import { Input, Menu, MenuItemProps, Segment } from "semantic-ui-react";
import About from "./tabs/About";

enum Tabs {
    ABOUT = 'about',
    CHARACTERS = 'characters',
    EPISODES = 'episodes',
    CHAPTERS = 'chapters'
}

const AnimeDetailsMenu = () => {
    const [activeTab, setActiveTab] = useState(Tabs.ABOUT);

    const handleItemClick = (_e: MouseEvent<HTMLAnchorElement>, data: MenuItemProps) => {
        if (data.name && Object.values(Tabs).includes(data.name as Tabs)) {
            setActiveTab(data.name as Tabs);
        }
    }

    return (
        <>
            <Menu attached='top' tabular>
                <Menu.Item
                    name={Tabs.ABOUT}
                    active={activeTab === Tabs.ABOUT}
                    onClick={handleItemClick}
                    content='About'
                />
                <Menu.Item
                    name={Tabs.CHARACTERS}
                    active={activeTab === Tabs.CHARACTERS}
                    onClick={handleItemClick}
                    content='Characters'
                />
                <Menu.Item
                    name={Tabs.EPISODES}
                    active={activeTab === Tabs.EPISODES}
                    onClick={handleItemClick}
                    content='Episodes'
                />
                <Menu.Item
                    name={Tabs.CHAPTERS}
                    active={activeTab === Tabs.CHAPTERS}
                    onClick={handleItemClick}
                    content='Chapters'
                />
                <Menu.Menu position='right'>
                    <Menu.Item>
                        <Input
                            transparent
                            icon={{ name: 'search', link: true }}
                            placeholder='Search users...'
                        />
                    </Menu.Item>
                </Menu.Menu>
            </Menu>
            <Segment attached='bottom' className='dark-theme'>
                <About />
            </Segment>
        </>
    )
}

export default AnimeDetailsMenu;