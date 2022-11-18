import React, { useEffect, useState } from "react";
import { Grid, List } from "semantic-ui-react";
import { User } from "../../../app/models/user";
import UserDetails from "../details/UserDetails";
import UserForm from "../form/UserForm";
import UserList from "./UserList";
import axios from 'axios';



export default function UserDashboard(){
    const [users, setCompanies] = useState<User[]>([]);

  useEffect(() => {
    axios.get<User[]>('https://localhost:7294/api/users').then(response => {
      setCompanies(response.data);
    })
  }, [])
    return (
        <Grid>
            <Grid.Column width='10'>
                <UserList users={users}/>
            </Grid.Column>
            <Grid.Column width='6'>
                {users[0] &&
                    <UserDetails user={users[0]}/> }
                {users[0] &&
                    <UserForm user={users[0]}/>}
            </Grid.Column>
        </Grid>
    )
}