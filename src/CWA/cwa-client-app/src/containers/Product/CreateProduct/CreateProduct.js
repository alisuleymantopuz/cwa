import React, { Component } from 'react';
import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import * as errorHandlerActions from '../../../store/actions/errorHandlerActions';
import SuccessModal from '../../../components/Modals/SuccessModal/SuccessModal';
import ErrorModal from '../../../components/Modals/ErrorModal/ErrorModal';
import DynamicFormGenerator from "react-interactive-dynamic-form-generator";

class CreateProduct extends Component {
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
            },
            unitPrice: {
                elementType: "input",
                elementConfig: {
                    type: "number",
                    placeholder: "Unit price"
                },
                value: "",
                validation: {
                    required: true,
                    error: "Unit price is required."
                },
                valid: false,
                touched: false
            },
            productRegisterDate: {
                elementType: "date",
                elementConfig: {
                    type: "date",
                    placeholder: "Product register date"
                },
                value: '',
                validation: {
                    required: true,
                    error: "Product register date is required."
                },
                valid: false,
                touched: false
            }
        }
    }

    createProduct = (form) => {
        const productToCreate = {
            name: form.name,
            unitPrice: form.unitPrice,
            productRegisterDate: form.productRegisterDate
        }
        const url = '/api/products';
        this.props.onCreateProduct(url, productToCreate, { ...this.props });
    }

    render() {
        return (
            <div className="FormContainer">
                <DynamicFormGenerator formFields={this.state.formFields} onFormSubmit={form => this.createProduct(form)} />
                <SuccessModal show={this.props.showSuccessModal}
                    modalHeaderText={'Success message'}
                    modalBodyText={'Action completed successfully'}
                    okButtonText={'OK'}
                    successClick={() => this.props.onCloseSuccessModal('/products', { ...this.props })} />
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
        onCreateProduct: (url, product, props) => dispatch(repositoryActions.postData(url, product, props)),
        onCloseSuccessModal: (url, props) => dispatch(repositoryActions.closeSuccessModal(props, url)),
        onCloseErrorModal: () => dispatch(errorHandlerActions.closeErrorModal())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(CreateProduct);
