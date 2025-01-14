import { Container } from "semantic-ui-react";
import NavBar from "./navbar/NavBar";
import { Outlet } from "react-router-dom";

function App() {
  return (
    <>
      <NavBar />
      <Container className='app-container'>
        <Outlet />
      </Container>
    </>
  )
}

export default App
