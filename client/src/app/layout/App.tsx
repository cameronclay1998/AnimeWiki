import { Container } from "semantic-ui-react";
import NavBar from "./navbar/NavBar";
import AnimeDashboard from "../../features/animes/dashboard/AnimeDashboard";

function App() {
  return (
    <>
      <NavBar />
      <Container className='app-container'>
        <AnimeDashboard />
      </Container>
    </>
  )
}

export default App
