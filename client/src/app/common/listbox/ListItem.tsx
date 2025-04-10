import { Button, ButtonGroup, Item } from "semantic-ui-react";

export interface MyListItem {
    id: string,
    photoUrl: string,
    title: string,
    releaseDate: string,
    description: string
}

interface Props {
    isAdmin: boolean,
    item: MyListItem,
    openDetails: (id: string) => void,
    deleteItem: (id: string) => void
}

const ListItem = ({ isAdmin, item, openDetails, deleteItem }: Props) => {
    return (
        <Item key={item.id}>
            <Item.Image src={item.photoUrl || '/assets/default-item.png'} />
            <Item.Content>
                <Item.Header as='a'>{item.title}</Item.Header>
                <Item.Meta>{item.releaseDate}</Item.Meta>
                <Item.Description>{item.description}</Item.Description>
                <Item.Extra>
                    {/* <AnimeGenreList anime={anime} /> */}
                    <ButtonGroup style={{ marginTop: '30px' }} floated="right">
                        {isAdmin && (
                            <Button
                                onClick={() => { deleteItem(item.id) }}
                                floated='right'
                                inverted
                                content='DeleteItem'
                                color='red'
                            />
                        )}
                        <Button
                            onClick={() => { openDetails(item.id) }}
                            floated='right'
                            inverted
                            content='View Details'
                            color='purple'
                        />
                    </ButtonGroup>
                </Item.Extra>
            </Item.Content>
        </Item>
    )
}

export default ListItem;