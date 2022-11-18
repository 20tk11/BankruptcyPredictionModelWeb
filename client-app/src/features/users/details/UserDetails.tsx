import React from "react";
import { Button, Card, Icon, Item, Label, Segment } from "semantic-ui-react";
import { User } from "../../../app/models/user";

interface Props {
    user: User;
}
export default function UserDetails({user}: Props){
    console.log(user)
    return (
        <Card>
            <Card.Content>
                <Icon className='large bug icon' name='user circle'/>
                <Card.Header style={{display: 'inline'}}>{user.firstName + ' ' + user.lastName}</Card.Header>
                {/* <Card.Meta>
                    <div className="row">
                        <div className="column_left">
                            <div className="text">{"2 days ago"}</div>
                        </div>
                        <div className="column_right">
                            <div className="text">{"Admin"}</div>
                        </div>
                    </div>
                </Card.Meta> */}
                {/* <Card.Description>
                    <p></p>
                </Card.Description> */}
            </Card.Content>
            <Card.Content>
                <Button basic color='green' content='Edit'/>
                <Button basic color='red' content='Remove'/>
            </Card.Content>
            {/* <div class="extra content">
                <div class="right floated author">
                    <img class="ui avatar image" src="/images/avatar/small/matt.jpg"> Matt
                </div>
            </div> */}
        </Card>
    )
}