import { Container, Item } from "semantic-ui-react";
import ListItem, { MyListItem } from "./ListItem";

interface Props {
    loading: boolean,
    data: MyListItem[],
    isAdmin: boolean,
    openDetails: (id: string) => void,
    deleteItem: (id: string) => void
}

const ListBox = ({ 
    loading, 
    data, 
    isAdmin, 
    openDetails, 
    deleteItem 
} : Props) => {
    return (
        <Container className='dark-theme'>
            {
                loading
                    ? <div>Loading...</div>
                    : (
                        data.length < 1
                            ? <div>No Content.</div>
                            : (
                                <Item.Group>
                                    {data.map(item => (
                                        <ListItem
                                            isAdmin={isAdmin}
                                            item={item}
                                            openDetails={openDetails}
                                            deleteItem={deleteItem}
                                        />
                                    ))}
                                </Item.Group>
                            )
                    )
            }
        </Container>
    )
}

export default ListBox;