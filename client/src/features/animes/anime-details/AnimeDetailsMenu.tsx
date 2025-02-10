import { useState, MouseEvent, useCallback } from "react";
import { Container, Input, Menu, MenuItemProps, Segment } from "semantic-ui-react";
import About from "./tabs/About";
import NotImplemented from "../../../app/common/NotImplemented";

enum Tabs {
    ABOUT = 'about',
    CHARACTERS = 'characters',
    EPISODES = 'episodes',
    CHAPTERS = 'chapters'
}

const AnimeDetailsMenu = () => {
    const [activeTab, setActiveTab] = useState(Tabs.ABOUT);

    const isActiveTab = useCallback((tab: string) => activeTab === tab, [activeTab]);

    const handleItemClick = (_e: MouseEvent<HTMLAnchorElement>, data: MenuItemProps) => {
        if (data.name && Object.values(Tabs).includes(data.name as Tabs)) {
            setActiveTab(data.name as Tabs);
        }
    }

    return (
        <Container fluid style={{height: '100%'}}>
            <Menu attached='top' tabular>
                <Menu.Item
                    name={Tabs.ABOUT}
                    active={isActiveTab(Tabs.ABOUT)}
                    onClick={handleItemClick}
                    content='About'
                />
                <Menu.Item
                    name={Tabs.CHARACTERS}
                    active={isActiveTab(Tabs.CHARACTERS)}
                    onClick={handleItemClick}
                    content='Characters'
                />
                <Menu.Item
                    name={Tabs.EPISODES}
                    active={isActiveTab(Tabs.EPISODES)}
                    onClick={handleItemClick}
                    content='Episodes'
                />
                <Menu.Item
                    name={Tabs.CHAPTERS}
                    active={isActiveTab(Tabs.CHAPTERS)}
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
            <Segment attached='bottom' className='dark-theme' style={{height: '100%'}}>
                {isActiveTab(Tabs.ABOUT) && <About />}
                {isActiveTab(Tabs.CHARACTERS) && <NotImplemented />}
                {isActiveTab(Tabs.EPISODES) && <NotImplemented />}
                {isActiveTab(Tabs.CHAPTERS) && <NotImplemented />}
            </Segment>
        </Container>
    )
}

export default AnimeDetailsMenu;