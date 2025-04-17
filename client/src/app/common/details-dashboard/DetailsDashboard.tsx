import {
    Button,
    Container,
    Grid,
    GridColumn,
    Image
} from "semantic-ui-react";
import { useNavigate } from "react-router-dom";
import { observer } from "mobx-react-lite";
import { useStore } from "../../stores/store";
import DetailsMenu from "./DetailsMenu";

export default observer(function DetailsDashboard() {
    const { mangaStore } = useStore();
    const { selectedManga } = mangaStore;

    const navigate = useNavigate();

    return (
        <Container fluid>
            <Button style={{ marginBottom: '10px' }} onClick={() => { navigate('/manga') }}>Back</Button>
            <Grid>
                <GridColumn width={6}>
                    <Image src={selectedManga?.photos[0].url} size='large' />
                </GridColumn>
                <GridColumn width={10}>
                    <DetailsMenu />
                </GridColumn>
            </Grid>
        </Container>
    )
})