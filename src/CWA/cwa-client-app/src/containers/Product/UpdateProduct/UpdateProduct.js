import React, { Component } from 'react';
import { connect } from 'react-redux';
import * as repositoryActions from '../../../store/actions/repositoryActions';
import * as errorHandlerActions from '../../../store/actions/errorHandlerActions';
import SuccessModal from '../../../components/Modals/SuccessModal/SuccessModal';
import ErrorModal from '../../../components/Modals/ErrorModal/ErrorModal';
import DynamicFormGenerator from "react-interactive-dynamic-form-generator";
import moment from 'moment';

class UpdateProduct extends Component {
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
        });
    }

    componentDidMount = () => {
        const id = this.props.match.params.id;
        const url = '/api/products/' + id;
        this.props.onGetProductById(url, { ...this.props });
    }

    componentWillReceiveProps = (nextProps) => {
        let fields = this.state.formFields;
        if (fields) {
            if (fields.name) {
                fields.name.value = nextProps.data.name;
                fields.name.valid = true;
            }

            if (fields.unitPrice) {
                fields.unitPrice.value = nextProps.data.unitPrice;
                fields.unitPrice.valid = true;
            }

            if (fields.productRegisterDate) {
                fields.productRegisterDate.value = moment(nextProps.data.productRegisterDate).format("YYYY-MM-DD");
                fields.productRegisterDate.valid = true;
            }

            this.setState({ formFields: fields });
        }
    }

    updateProduct = (form) => {
        const productToUpdate = {
            id: this.props.data.id,
            name: form.name,
            unitPrice: form.unitPrice,
            productRegisterDate: form.productRegisterDate
        }
        const url = '/api/products/' + this.props.data.id;
        this.props.onUpdateProduct(url, productToUpdate, { ...this.props });
    }

    render() {
        return (
            <div className="FormContainer">
                <DynamicFormGenerator formFields={this.state.formFields} onFormSubmit={form => this.updateProduct(form)} />

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
        data: state.repository.data,
        showSuccessModal: state.repository.showSuccessModal,
        showErrorModal: state.errorHandler.showErrorModal,
        errorMessage: state.errorHandler.errorMessage
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        onGetProductById: (url, props) => dispatch(repositoryActions.getData(url, props)),
        onUpdateProduct: (url, owner, props) => dispatch(repositoryActions.putData(url, owner, props)),
        onCloseSuccessModal: (url, props) => dispatch(repositoryActions.closeSuccessModal(props, url)),
        onCloseErrorModal: () => dispatch(errorHandlerActions.closeErrorModal())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(UpdateProduct);