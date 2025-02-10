import { Container, Icon } from "semantic-ui-react";

const NotImplemented = () => {
    return (
        <Container text textAlign="center" fluid>
            <Icon name='wrench' size='large'/>
            <span>Sorry, this is still under construction.</span>
        </Container>
    )
}

export default NotImplemented;