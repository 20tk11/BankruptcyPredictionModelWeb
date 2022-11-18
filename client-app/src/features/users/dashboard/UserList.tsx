import React from "react";
import { Button,  Item, Label,  Segment } from "semantic-ui-react";
import { User } from "../../../app/models/user";

interface Props {
    users: User[];
}
export default function UserList({users}: Props){
    return (
        <Segment>
            <Item.Group divided >
                {users.map(user =>(
                    <Item key={user.id}>
                        <Item.Content>
                            <Item.Header as='a'>{user.firstName + ' ' + user.lastName}</Item.Header>
                            <Item.Meta>{user.emailAddress}</Item.Meta>
                            <Item.Description>
                            <div className="row">
                                <div className="column_left">
                                    <div className="text">{"Organization: "}</div>
                                    <div className="text">{"Phone Number: "}</div>
                                    <div className="text">{"Country: "}</div>
                                    <div className="text">{"City: "}</div>
                                    <div className="text">{"User Create Date: "}</div>
                                    <div className="text">{"User Update Date "}</div>
                                </div>
                                <div className="column_right">
                                    <div className="text">{user.organization}</div>
                                    <div className="text">{user.phoneNumber}</div>
                                    <div className="text">{user.country}</div>
                                    <div className="text">{user.city}</div>
                                    <div className="text">{user.userCreateDate.toString()}</div>
                                    <div className="text">{user.userLastUpdateDate.toString()}</div>
                                </div>
                            </div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='blue'/>
                                <Label basic content={"Admin"}></Label>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}