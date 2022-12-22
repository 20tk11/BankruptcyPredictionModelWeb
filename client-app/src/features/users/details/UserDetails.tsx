import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { Link, NavLink, useParams } from "react-router-dom";
import { Button, Container, Grid, Header, Item, Segment } from "semantic-ui-react";
import LoadingComponent from "../../../app/layouts/loading";
import { useStore } from "../../../app/stores/store";
import UserList from "../dashboard/UserList";
import UserDetailsContact from "./UserDetailsContact";
import UserDetailsMain from "./UserDetailsMain";
import CompanyDashboard from "../../companies/dashboard/CompaniesDashboard";
import { idText } from "typescript";


export default observer(function UserDetails() {
    const { userStore, companyStore } = useStore();
    const { selectedUser: user, loadUser, loadUsers, loadingInitial } = userStore;
    const { id } = useParams();
    useEffect(() => {
        if (id) {
            companyStore.setSelectedUser(id)
            loadUsers();
            loadUser(id)


        }
    }, [id, loadUser, loadUsers, companyStore])
    if (loadingInitial || !user) return <LoadingComponent />;
    return (
        <Grid stackable  >
            <Grid.Column stretched mobile={16} tablet={8} computer={5}>
                <UserDetailsMain user={user} />
            </Grid.Column>
            <Grid.Column stretched mobile={16} tablet={8} computer={5}>
                <UserDetailsContact user={user} />
            </Grid.Column>
            <Grid.Column mobile={16} tablet={8} computer={5}>
                <Button as={Link} to={`/editUser/${user.id}`} basic color='blue' content='Edit' />
                <Button as={Link} to={`/mainPage`} basic color='grey' content='Cancel' />
            </Grid.Column>
            <Grid.Column mobile={16} tablet={16} computer={10} >
                <Segment>
                    <Item.Header style={{ marginBottom: "35px" }}>Companies
                        <Button as={NavLink} to={`/createCompany/user/${id}`} positive content='Add Company' floated="right" />
                    </Item.Header >


                    <CompanyDashboard />
                </Segment>
            </Grid.Column>
            {/* <Grid className="details">
                <UserDetailsMain user={user} />
            </Grid>
            <Grid className="details">
                <UserDetailsMain user={user} />
            </Grid> */}
        </Grid>
    )
})