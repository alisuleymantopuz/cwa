import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Jumbotron, Container } from 'react-bootstrap';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import TagProducts from '../../../components/TagOperations/TagProducts/TagProducts';
import Aux from '../../../hoc/Auxiliary/Auxiliary';

class TagDetails extends Component {

    componentDidMount = () => {
        let id = this.props.match.params.id;
        let url = '/api/tags/' + id + '/products';
        this.props.onGetData(url, { ...this.props })
    }

    render() {
        const tag = this.props.data;
        if (tag) {
            return (
                <Aux>
                    <Jumbotron fluid>
                        <Container>
                            <h1>
                                {tag.name}</h1>
                            <p>
                                This tag has the products assigned below.
                            </p>
                            {this.renderCountOfProductsCountConditionally(tag)}
                            <img src="https://picsum.photos/300/300" />
                        </Container>
                    </Jumbotron>
                    <TagProducts products={tag.products} key={tag.id} />
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
                            Tag not found.</h1>
                        <p>
                            The tag in this details page is not found.
                        </p>
                    </Container>
                </Jumbotron>
            </Aux>
        )
    }

    renderCountOfProductsCountConditionally = (tag) => {
        let countOfProducts = null;
        if (tag.products && tag.products.length > 0) {
            countOfProducts = (
                <p>
                    <span className={'text-success'}>Product Count: {tag.products.length}</span>
                </p>
            );
        }
        else {
            countOfProducts = (
                <p>
                    <strong>No products aassigned to this tag!</strong>
                </p>
            );
        }
        return countOfProducts;
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
export default connect(mapStateToProps, mapDispatchToProps)(TagDetails);
