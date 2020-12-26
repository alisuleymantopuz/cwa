import React from 'react';
import './Navigation.css';
import { Col, Navbar, Nav, Button, Form, FormControl } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';

const navigation = (props) => {
    return (
        <Col>
            <Navbar bg="dark" variant="dark" expand="lg">
                <Navbar.Brand href={'/'}>Your catalog!</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="mr-auto">
                        <NavLink to={'/tags'} activeClassName="active" className="nav-link">Tags</NavLink>
                        <NavLink to={'/products'} activeClassName="active" className="nav-link">Products</NavLink>
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