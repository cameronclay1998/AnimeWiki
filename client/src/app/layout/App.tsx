import axios from "axios";
import { useEffect, useState } from "react"
import { Header, List } from "semantic-ui-react";

function App() {
  const [animes, setAnimes] = useState([])

  useEffect(() => {
    axios.get('http://localhost:5000/api/animes')
      .then(response => setAnimes(response.data))
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Animes' />
      <List>
        {animes.map(anime => <List.Item key={anime.id}>{anime.title}</List.Item>)}
      </List>
    </div>
  )
}

export default App
