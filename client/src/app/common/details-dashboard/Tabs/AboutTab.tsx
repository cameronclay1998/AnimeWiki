import { Card, CardDescription, CardMeta, Menu, MenuItem } from "semantic-ui-react";
import { useStore } from "../../../stores/store";
import { observer } from "mobx-react-lite";
import NoContent from "../../NoContent";
import { formatDateTime } from "../../../../utils/date";

const AboutTab = observer(() => {
    const {mangaStore} = useStore();
    const {selectedManga} = mangaStore;

    if (!selectedManga) return <NoContent />
    
    return (
        <Card fluid className='dark-theme' style={{height: '100%', display: 'flex'}}>
            <h2 style={{marginBottom: '0px'}}>{selectedManga.title}</h2>
            <CardMeta>{formatDateTime(new Date(selectedManga.published))}</CardMeta>
            <CardDescription style={{marginTop: '30px'}}>{selectedManga.description}</CardDescription>
            <Menu style={{marginTop: 'auto'}}>
                {selectedManga.genres.map(g => (
                    <MenuItem
                        style={{
                            border: 'solid white 1px',
                            borderRadius: '10px',
                            marginRight: '5px'
                        }}
                    >
                        {g}
                    </MenuItem>
                ))}
            </Menu>
        </Card>
    )
})

export default AboutTab;