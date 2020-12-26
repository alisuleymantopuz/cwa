import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Jumbotron, Container } from 'react-bootstrap';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import Moment from 'react-moment';
import CurrencyFormat from 'react-currency-format';

class ProductDetails extends Component {
    componentDidMount = () => {
        let id = this.props.match.params.id;
        let url = '/api/products/' + id + '/tags';
        this.props.onGetData(url, { ...this.props })
    }

    render() {
        const product = this.props.data;
        if (product) {
            return (
                <Aux>
                    <Jumbotron fluid>
                        <Container>
                            <h1>
                                {product.name}</h1>
                            <p>
                                Unit price: <CurrencyFormat value={product.unitPrice} displayType={'text'} thousandSeparator={true} prefix={'€'} />
                            </p>
                            <p>
                                Register date: <Moment format="DD/MM/YYYY">{product.productRegisterDate}</Moment>
                            </p>
                        </Container>
                    </Jumbotron>
                </Aux>
            )
        } else {
            return (this.renderNotFound());
        }
    }

    renderNotFound = () => {
        return (
            <Aux>
                <Jumbotron fluid>
                    <Container>
                        <h1>
                            Product not found.</h1>
                        <p>
                            The product in this details page is not found.
                        </p>
                    </Container>
                </Jumbotron>
            </Aux>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.repository.data
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(ProductDetails);
