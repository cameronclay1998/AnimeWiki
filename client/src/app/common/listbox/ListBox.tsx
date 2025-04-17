import { Container, Grid, GridColumn, Item, Placeholder, PlaceholderHeader, PlaceholderImage, PlaceholderLine } from "semantic-ui-react";
import ListItem, { MyListItem } from "./ListItem";
import NoContent from "../NoContent";

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
        <Container>
            {
                loading
                    ? <Placeholders />
                    : (
                        data.length < 1
                            ? <NoContent />
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

const Placeholders = () => {
    const placeholders = [];
    
    for (let i = 0; i < 50; i++) {
        placeholders.push(
            <Grid>
                <GridColumn width={3}>
                    <Placeholder inverted style={{ height: 250, width: 175, margin: '0px' }}>
                        <PlaceholderImage />
                    </Placeholder>
                </GridColumn>
                <GridColumn width={11}>
                    <Placeholder inverted>
                    <PlaceholderHeader>
                        <PlaceholderLine length='short' />
                    </PlaceholderHeader>
                    </Placeholder>
                    <Placeholder style={{ margin: '0px' }} inverted>
                        <PlaceholderLine length='medium' />
                    </Placeholder>
                    <Placeholder fluid inverted>
                        <PlaceholderLine length='full' />
                        <PlaceholderLine length='full' />
                        <PlaceholderLine length='very long' />
                        <PlaceholderLine length='full'/>
                        <PlaceholderLine />
                    </Placeholder>
                </GridColumn>
            </Grid>
        );
    }

    return placeholders;
}

export default ListBox;