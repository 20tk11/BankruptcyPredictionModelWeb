import { SyntheticEvent, useState } from "react"
import { Link } from "react-router-dom"
import { Item, Button, Label, Segment } from "semantic-ui-react"
import loading from "../../../app/layouts/loading"
import { User } from "../../../app/models/user"
import { useStore } from "../../../app/stores/store"


interface Props {
    user: User
}

export default function UserListItem({ user }: Props) {
    const { userStore } = useStore();
    const { deleteUser, loading } = userStore;
    const [target, setTarget] = useState('');

    function handleUserDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        deleteUser(id);
    }
    return (

        <Segment.Group>
            <Segment>
                <Item.Group>
                    <Item className="item-content">
                        <Item.Image size='tiny' src="/assets/logo.png" />

                        <Item.Content verticalAlign="middle" >
                            <Item.Header as={Link} to={`/users/${user.id}`}>
                                {user.firstName} {user.lastName}
                            </Item.Header>
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
            <Segment secondary clearing>
                <Button as={Link} to={`/users/${user.id}`} color='teal' floated='left' content='View' />
                <Button onClick={(e) => handleUserDelete(e, user.id)} color='red' floated='left' content='Delete' />
            </Segment>
        </Segment.Group>
    )
}