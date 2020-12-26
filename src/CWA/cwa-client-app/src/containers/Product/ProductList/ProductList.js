import React, { Component } from 'react';
import { Table, Col, Row, Button } from 'react-bootstrap';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import Product from '../../../components/ProductOperations/Product/Product';

class ProductList extends Component {

    componentDidMount = () => {
        let url = '/api/products';
        this.props.onGetData(url, { ...this.props });
    }

    render() {
        let products = [];
        if (this.props.data && this.props.data.length > 0) {
            products = this.props.data.map((product) => {
                return (
                    <Product key={product.id} product={product} {...this.props} />
                )
            })
        }
        return (
            <Aux>
                <Row>
                    <Col>
                        <Table responsive striped>
                            <thead>
                                <tr>
                                    <th colSpan="6">
                                        <Button href="/createProduct" className="float-right">
                                            Create Product
                                        </Button>
                                    </th>
                                </tr>
                                <tr>
                                    <th>Id</th>
                                    <th>Name</th>
                                    <th>Register Date</th>
                                    <th>Unit Price</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                {products}
                            </tbody>
                        </Table>
                    </Col>
                </Row>
            </Aux>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.data
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ProductList);