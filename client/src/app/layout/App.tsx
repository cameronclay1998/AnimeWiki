import { Container } from "semantic-ui-react";
import NavBar from "./navbar/NavBar";
import { Outlet } from "react-router-dom";

function App() {
  return (
    <Container className='app-container' fluid>
      <NavBar />
      <Outlet />
    </Container>
  )
}

export default App
