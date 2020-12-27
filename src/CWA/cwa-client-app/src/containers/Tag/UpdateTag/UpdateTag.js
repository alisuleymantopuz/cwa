import React, { Component } from 'react';
import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import * as errorHandlerActions from '../../../store/actions/errorHandlerActions';
import SuccessModal from '../../../components/Modals/SuccessModal/SuccessModal';
import ErrorModal from '../../../components/Modals/ErrorModal/ErrorModal';
import DynamicFormGenerator from "react-interactive-dynamic-form-generator";

class UpdateTag extends Component {
    state = {
        formFields: {}
    }

    componentWillMount = () => {
        this.setState({
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
        });
    }

    componentDidMount = () => {
        const id = this.props.match.params.id;
        const url = '/api/tags/' + id;
        this.props.onGetTagById(url, { ...this.props });
    }

    componentWillReceiveProps = (nextProps) => {
        let fields = this.state.formFields;
        if (fields && fields.name) {
            fields.name.value = nextProps.data.name;
            fields.name.valid = true;
            this.setState({ formFields: fields });
        }
    }

    updateTag = (form) => {
        const tagToUpdate = {
            id: this.props.data.id,
            name: form.name
        }
        const url = '/api/tags/' + this.props.data.id;
        this.props.onUpdateTag(url, tagToUpdate, { ...this.props });
    }

    render() {
        return (
            <div className="FormContainer">
                <DynamicFormGenerator formFields={this.state.formFields} onFormSubmit={form => this.updateTag(form)} />

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
        data: state.repository.data,
        showSuccessModal: state.repository.showSuccessModal,
        showErrorModal: state.errorHandler.showErrorModal,
        errorMessage: state.errorHandler.errorMessage
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        onGetTagById: (url, props) => dispatch(repositoryActions.getData(url, props)),
        onUpdateTag: (url, owner, props) => dispatch(repositoryActions.putData(url, owner, props)),
        onCloseSuccessModal: (url, props) => dispatch(repositoryActions.closeSuccessModal(props, url)),
        onCloseErrorModal: () => dispatch(errorHandlerActions.closeErrorModal())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UpdateTag);
