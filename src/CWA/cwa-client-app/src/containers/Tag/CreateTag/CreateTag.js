import React, { Component } from 'react';
import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import * as errorHandlerActions from '../../../store/actions/errorHandlerActions';
import SuccessModal from '../../../components/Modals/SuccessModal/SuccessModal';
import ErrorModal from '../../../components/Modals/ErrorModal/ErrorModal';
import DynamicFormGenerator from "react-interactive-dynamic-form-generator";

class CreateTag extends Component {
    state = {
        formFields: {
            name: {
                elementType: "input",
                elementConfig: {
                    type: "text",
                    placeholder: "Name"
                },
                value: "",
                validation: {
                    required: true,
                    error: "Name is required."
                },
                valid: false,
                touched: false
            }
        }
    }

    createTag = (form) => {
        const tagToCreate = {
            name: form.name
        }
        const url = '/api/tags';
        this.props.onCreateTag(url, tagToCreate, { ...this.props });
    }

    render() {
        return (
            <div className="FormContainer">
                <DynamicFormGenerator formFields={this.state.formFields} onFormSubmit={form => this.createTag(form)} />

                <SuccessModal show={this.props.showSuccessModal}
                    modalHeaderText={'Success message'}
                    modalBodyText={'Action completed successfully'}
                    okButtonText={'OK'}
                    successClick={() => this.props.onCloseSuccessModal('/tags', { ...this.props })} />
                <ErrorModal show={this.props.showErrorModal}
                    modalHeaderText={'Error message'}
                    modalBodyText={this.props.errorMessage}
                    okButtonText={'OK'} closeModal={() => this.props.onCloseErrorModal()} />
            </div>
        );
    }
}

const mapStateToProps = (state) => {
    return {
        showSuccessModal: state.repository.showSuccessModal,
        showErrorModal: state.errorHandler.showErrorModal,
        errorMessage: state.errorHandler.errorMessage
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        onCreateTag: (url, tag, props) => dispatch(repositoryActions.postData(url, tag, props)),
        onCloseSuccessModal: (url, props) => dispatch(repositoryActions.closeSuccessModal(props, url)),
        onCloseErrorModal: () => dispatch(errorHandlerActions.closeErrorModal())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(CreateTag);
