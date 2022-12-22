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

export default function UserDetailsMain({ user }: Props) {
    const { userStore } = useStore();

    return (
        <Segment.Group >
            <Segment>
                <Item.Group>
                    <Item className="item-content">
                        <Item.Image size='tiny' src="/assets/logo.png" />

                        <Item.Content verticalAlign="middle" >
                            <Item.Header >
                                {user.firstName} {user.lastName}
                            </Item.Header >
                            <Item.Description >
                                {user.organization ? user.organization : "Unspecified"}
                            </Item.Description>
                            <Item.Meta >
                                {user.country ? user.country : "Unspecified"}
                            </Item.Meta>
                            <Item.Extra >
                                {user.city ? user.city : "Unspecified"}
                            </Item.Extra>
                            <Item.Description >
                                {user.role}
                            </Item.Description>
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