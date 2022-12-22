import { Button, Grid } from "semantic-ui-react";
import UserList from "./UserList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import LoadingComponent from "../../../app/layouts/loading";
import { NavLink } from "react-router-dom";



export default observer(function UserDashboard() {
  const { userStore } = useStore();
  const { loadUsers, userRegistry } = userStore;

  useEffect(() => {
    if (userRegistry.size <= 0) {
      loadUsers();
    }

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [loadUsers, userRegistry.size])


  if (userStore.loadingInitial) return <LoadingComponent content='Loading Bancruptcy Prediction App' />
  return (
    <Grid>
      <Grid.Column >
        {/* <Button as={NavLink} to='/createUser' positive content='Add User' /> */}
        <UserList
        />
      </Grid.Column>
    </Grid>
  )
})