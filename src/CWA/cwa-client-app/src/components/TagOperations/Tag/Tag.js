import React from 'react';
import Aux from '../../../hoc/Auxiliary/Auxiliary';
import { ButtonGroup, DropdownButton, Dropdown } from 'react-bootstrap';

const redirectToTagDetails = (id, history) => {
    history.push('/tagDetails/' + id);
}
const redirectToUpdateTag = (id, history) => {
    history.push('/updateTag/' + id);
}
const rediterctToDeleteTag = (id, history) => {
    history.push('/deleteTag/' + id);
}


const tag = (props) => {
    return (
        <Aux>
            <tr>
                <td>{props.tag.id}</td>
                <td>{props.tag.name}</td>
                <td><img src="https://picsum.photos/50/50" /></td>
                <td>
                    <ButtonGroup className="float-left">
                        <DropdownButton as={ButtonGroup} title="Actions">
                            <Dropdown.Item onClick={() => redirectToTagDetails(props.tag.id, props.history)}>Details</Dropdown.Item>
                            <Dropdown.Item onClick={() => redirectToUpdateTag(props.tag.id, props.history)}>Update</Dropdown.Item>
                            <Dropdown.Item onClick={() => rediterctToDeleteTag(props.tag.id, props.history)}>Delete</Dropdown.Item>
                        </DropdownButton>
                    </ButtonGroup>
                </td>
            </tr>
        </Aux>
    )
}
export default tag;