import React, { Component } from 'react';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import { Jumbotron, Container, Button } from 'react-bootstrap';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import * as errorHandlerActions from '../../../store/actions/errorHandlerActions';
import { connect } from 'react-redux';
import Moment from 'react-moment';
import SuccessModal from '../../../components/Modals/SuccessModal/SuccessModal';
import ErrorModal from '../../../components/Modals/ErrorModal/ErrorModal';

class DeleteTag extends Component {

    redirectToTagList = () => {
        this.props.history.push('/tags');
    }

    deleteTag = (event) => {
        event.preventDefault();
        const url = "/api/tags/" + this.props.data.id;
        this.props.onDeleteTag(url, { ...this.props });
    }

    componentDidMount = () => {
        const id = this.props.match.params.id;
        const url = '/api/tags/' + id;
        this.props.onGetTagById(url, { ...this.props });
    }

    render() {
        let tag = { ...this.props.data };
        return (
            <Aux>
                <Jumbotron fluid>
                    <Container>
                        <h2>
                            Selected Tag: <b>{tag.name}</b></h2>
                        <Button type="submit" onClick={this.deleteTag} className="float-right">Delete</Button>
                        <Button onClick={this.redirectToTagList} className="float-right">Cancel</Button>
                    </Container>
                </Jumbotron>
                <SuccessModal show={this.props.showSuccessModal} modalHeaderText={'Success message'}
                    modalBodyText={'Action completed successfylly'}
                    okButtonText={'OK'}
                    successClick={() => this.props.onCloseSuccessModal('/tags', { ...this.props })} />
                <ErrorModal show={this.props.showErrorModal} modalHeaderText={'Error message'}
                    modalBodyText={this.props.errorMessage}
                    okButtonText={'OK'}
                    closeModal={() => this.props.onCloseErrorModal()} />
            </Aux>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        data: state.repository.data,
        showSuccessModal: state.repository.showSuccessModal,
        showErrorModal: state.errorHandler.showErrorModal,
        errorMessage: state.errorHandler.errorMessage
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        onGetTagById: (url, props) => dispatch(repositoryActions.getData(url, props)),
        onDeleteTag: (url, props) => dispatch(repositoryActions.deleteData(url, props)),
        onCloseSuccessModal: (url, props) => dispatch(repositoryActions.closeSuccessModal(props, url)),
        onCloseErrorModal: () => dispatch(errorHandlerActions.closeErrorModal())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(DeleteTag);
