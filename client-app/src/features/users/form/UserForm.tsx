import React from "react";
import { Button,  Form,  Item, Label,  Segment } from "semantic-ui-react";
import { User } from "../../../app/models/user";

interface Props {
    user: User;
}
export default function UserForm({user}: Props){
    return (
        <Segment>
            <Form>
                <Form.Input label="First Name" placeholder={user.firstName}/>
                <Form.Input type="password" label="Last Name" placeholder={user.lastName}/>
                <Form.Input label="Email Adress" placeholder={user.emailAddress}/>
                <Form.Input label="Login Name" placeholder={user.loginName}/>
                <Form.Input label="Login Password" placeholder={user.loginPassword}/>
                <Form.Input label="Phone Number" placeholder={user.phoneNumber}/>
                <Form.Input label="Country" placeholder={user.country}/>
                <Form.Input label="City" placeholder={user.city}/>
                <Button floated='right' positive type='submit' content='Submit'/>
                <Button floated='right' type='submit' content='Cancel'/>
            </Form>
        </Segment>
    )
}