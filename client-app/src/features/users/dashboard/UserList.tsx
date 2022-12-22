import { observer } from "mobx-react-lite";
import React, { Fragment, SyntheticEvent, useState } from "react";
import { Link } from "react-router-dom";
import { Button, Header, Item, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import UserListItem from "./UserListItem";


export default observer(function UserList() {


    const { userStore } = useStore();
    const { groupedUsers } = userStore;
    // const temp = groupedUsers[0];
    // groupedUsers[0] = groupedUsers[1];
    // groupedUsers[1] = temp;
    console.log(groupedUsers.sort((a, b) => (a[0].toLowerCase() > b[0].toLowerCase()) ? 1 : ((a[0].toLowerCase() < b[0].toLowerCase()) ? -1 : 0)));
    return (
        <>
            {groupedUsers.sort((a, b) => (a[0].toLowerCase() > b[0].toLowerCase()) ? 1 : ((a[0].toLowerCase() < b[0].toLowerCase()) ? -1 : 0)).map(([group, users]) => (
                <Fragment key={group}>
                    <Header sub color='teal'>
                        {group}
                    </Header>
                    <Segment>
                        <Item.Group divided >
                            {users.map(user => (
                                <UserListItem key={user.id} user={user} />
                            ))}
                        </Item.Group>
                    </Segment>
                </Fragment>
            ))}


        </>

    )
})