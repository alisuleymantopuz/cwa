import React from 'react';
import { Row, Col, Table } from 'react-bootstrap';
import Moment from 'react-moment';
import CurrencyFormat from 'react-currency-format';

const tagProducts = (props) => {
    let products = [];
    if (props.products) {
        products = props.products;
    }
    return (
        <Row>
            <Col md={12}>
                <Table responsive striped>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Register date</th>
                            <th>Price</th>
                            <th>Photo</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            products.map((p) => {
                                return (
                                    <tr key={p.product.id}>
                                        <td>{p.product.id}</td>
                                        <td>{p.product.name}</td>
                                        <td><Moment format="DD/MM/YYYY">{p.product.productRegisterDate}</Moment></td>
                                        <td><CurrencyFormat value={p.product.unitPrice} displayType={'text'} thousandSeparator={true} prefix={'€'} /></td>
                                        <td><img src="https://picsum.photos/50/50" /></td>
                                    </tr>
                                );
                            })
                        }
                    </tbody>
                </Table>
            </Col>
        </Row>
    )
}
export default tagProducts;