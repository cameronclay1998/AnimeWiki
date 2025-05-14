import { Container, Grid, Search } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { useEffect, useMemo, useState } from "react";
import { observer } from "mobx-react-lite";
import Manga from "../../app/models/manga";
import ListItem from "../../app/common/listbox/ListItem";
import { mapToListItem } from "./MangaList";
import GenreMenu from "./GenreMenu";

export default observer(function MangaDashboard2() {
    const {mangaStore} = useStore();
    const {mangas, fetchManga} = mangaStore;

    const [loading, setLoading] = useState(false);
    
    useEffect(() => {
        const handleAsync = async () => {
            try {
                setLoading(true);
                await fetchManga();
            }
            catch (error) {
                console.log(error);
            }
            finally {
                setLoading(false);
            }
        }
        handleAsync();
    }, [])

    const mangaGroups = useMemo(() => {
        let groups: Manga[][] = [];
        for (let i = 0; i < mangas.length; i++) {
            const remainder = i % 3;
            if (remainder === 0) {
                groups.push([]);
            }
            groups[groups.length - 1].push(mangas[i]);
        }
        return groups;
    }, [mangas]);

    return (
        <Grid>
            <Grid.Column width={3}>
                <GenreMenu />
            </Grid.Column>
            <Grid.Column width={10}>
                <div style={{display:'flex', justifyContent:'space-between', marginBottom: '5px'}}>
                    <h3>Manga</h3>
                    <Search placeholder='Search...' />
                </div>
                <div style={{ border: 'solid white 1px', padding: '30px', height: 'calc(100vh - 200px)', overflow: 'auto' }}>
                    <Grid>
                        {mangaGroups.map(mg => (
                            <Grid.Row>
                                {mg.map(m => (
                                    <Grid.Column width={5}>
                                        <ListItem
                                            isAdmin={false}
                                            item={mapToListItem(m)}
                                            openDetails={() => { }}
                                            deleteItem={() => { }}
                                        />
                                    </Grid.Column>
                                ))}
                            </Grid.Row>
                        ))}
                    </Grid>
                </div>
            </Grid.Column>
        </Grid>
    )
})