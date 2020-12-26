import React from 'react';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import { ButtonGroup, DropdownButton, Dropdown } from 'react-bootstrap';
import Moment from 'react-moment';
import CurrencyFormat from 'react-currency-format';


const redirectToProductDetails = (id, history) => {
    history.push('/productDetails/' + id);
}
const redirectToUpdateProduct = (id, history) => {
    history.push('/updateProduct/' + id);
}
const rediterctToDeleteProduct = (id, history) => {
    history.push('/deleteProduct/' + id);
}


const product = (props) => {
    return (
        <Aux>
            <tr>
                <td>{props.product.id}</td>
                <td>{props.product.name}</td>
                <td><Moment format="DD/MM/YYYY">{props.product.productRegisterDate}</Moment></td>
                <td><CurrencyFormat value={props.product.unitPrice} displayType={'text'} thousandSeparator={true} prefix={'€'} /></td>
                <td>
                    <ButtonGroup className="float-left">
                        <DropdownButton as={ButtonGroup} title="Actions">
                            <Dropdown.Item onClick={() => redirectToProductDetails(props.product.id, props.history)}>Details</Dropdown.Item>
                            <Dropdown.Item bsStyle="success" onClick={() => redirectToUpdateProduct(props.product.id, props.history)}>Update</Dropdown.Item>
                            <Dropdown.Item bsStyle="danger" onClick={() => rediterctToDeleteProduct(props.product.id, props.history)}>Delete</Dropdown.Item>
                        </DropdownButton>
                    </ButtonGroup>
                </td>
            </tr>
        </Aux>
    )
}
export default product;