import React from 'react';
import './Navigation.css';
import { Col, Navbar, Nav, Button, Form, FormControl } from 'react-bootstrap';

const navigation = (props) => {
    return (
        <Col>
            <Navbar bg="dark" variant="dark" expand="lg">
                <Navbar.Brand href={'/'}>Your catalog!</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto">
                        <Nav.Link href={'/tags'}>Tags</Nav.Link>
                        <Nav.Link href={'/products'}>Products</Nav.Link>
                    </Nav>
                    <Form inline>
                        <FormControl type="text" placeholder="Search in products" className="mr-sm-2" />
                        <Button variant="outline-success">Search</Button>
                    </Form>
                </Navbar.Collapse>
            </Navbar>
        </Col>
    )
}
export default navigation;