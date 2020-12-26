import React from 'react';
import { Col, Row, Jumbotron, Container } from 'react-bootstrap';
import './Home.css';


const home = (props) => {

    return (
        <Row>
            <Col md={12}>
                <Jumbotron fluid>
                    <Container>
                        <h1>
                            Your catalog!</h1>
                        <p>
                            Welcome to Catalog web app!
                        </p>
                    </Container>
                </Jumbotron>
            </Col>
        </Row>
    )
}

export default home;