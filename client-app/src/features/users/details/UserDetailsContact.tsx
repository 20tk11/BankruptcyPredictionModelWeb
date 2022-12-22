import { useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import { Segment, Item, Button, Card, Icon } from "semantic-ui-react";
import LoadingComponent from "../../../app/layouts/loading";
import { User } from "../../../app/models/user";
import { useStore } from "../../../app/stores/store";
import userStore from "../../../app/stores/userStore";

interface Props {
    user: User
}

export default function UserDetailsContact({ user }: Props) {
    const { userStore } = useStore();

    return (
        <Segment.Group >
            <Segment>
                <Item.Group>
                    <Item className="item-content">
                        <Item.Content verticalAlign="middle" >
                            <Item.Header >
                                Contact Information
                            </Item.Header>
                            <Item.Description >
                                {user.userName ? user.userName : "Unspecified"}
                            </Item.Description>
                            <Item.Extra >
                                {user.email ? user.email : "Unspecified"}
                            </Item.Extra>
                            <Item.Extra >
                                {user.phoneNumber ? user.phoneNumber : "Unspecified"}
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
        </Segment.Group>

        // <Card >
        //     <Card.Content>
        //         <Icon className='large bug icon' name='user circle' />
        //         <Card.Header style={{ display: 'inline' }}>{user.firstName + ' ' + user.lastName}</Card.Header>
        //     </Card.Content>
        //     <Card.Content>
        //         <Button.Group >
        //             <Button as={Link} to={`/editUser/${user.id}`} basic color='blue' content='Edit' />
        //             <Button as={Link} to={`/users`} basic color='grey' content='Cancel' />
        //         </Button.Group>
        //     </Card.Content>
        // </Card>
    )
}