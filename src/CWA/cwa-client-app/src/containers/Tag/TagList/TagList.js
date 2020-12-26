import React, { Component } from 'react';
import { Table, Col, Row, Button } from 'react-bootstrap';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import Tag from '../../../components/TagOperations/Tag/Tag';


class TagList extends Component {

    componentDidMount = () => {
        let url = '/api/tags';
        this.props.onGetData(url, { ...this.props });
    }

    render() {
        let tags = [];
        if (this.props.data && this.props.data.length > 0) {
            tags = this.props.data.map((tag) => {
                return (
                    <Tag key={tag.id} tag={tag} {...this.props} />
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
                                    <th colSpan="4">
                                        <Button href="/createTag" className="float-right">
                                            Create Tag
                                        </Button>
                                    </th>
                                </tr>
                                <tr>
                                    <th>Id</th>
                                    <th>Name</th>
                                    <th>Photo</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                {tags}
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
        data: state.repository.data
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        onGetData: (url, props) => dispatch(repositoryActions.getData(url, props))
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(TagList);