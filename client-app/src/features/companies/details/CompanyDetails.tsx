import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { Link, NavLink, useParams } from "react-router-dom";
import { Button, Container, Grid, Header, Item, Segment } from "semantic-ui-react";
import LoadingComponent from "../../../app/layouts/loading";
import { useStore } from "../../../app/stores/store";
import CompanyDashboard from "../../companies/dashboard/CompaniesDashboard";
import CompanyDetailsData from "./CompanyDetailsData";
import CompanyDetailsMain from "./CompanyDetailsMain";
import UserDetailsMain from "./CompanyDetailsMain";


export default observer(function CompanyDetails() {
    const { userStore, companyStore } = useStore();
    const { selectedUser: user, loadUser, loadUsers } = userStore;
    const { selectedCompany: company, loadingInitial, loadCompanies, loadCompany } = companyStore;
    const { id, companyid } = useParams();
    useEffect(() => {
        if (id) {
            loadUsers();
            loadUser(id);
            loadCompanies(id);
            if (companyid) {
                loadCompany(id, companyid);
            }
            // loadUser()

        }
    }, [id, loadCompany, loadUser, companyStore, loadCompanies, loadUsers, user, companyid])
    if (loadingInitial || !user || !company) {
        console.log(userStore.userRegistry)
        console.log(companyStore.companyRegistry)
        console.log(company);
        console.log(user);
        console.log(id);
        console.log(companyid);
        return <LoadingComponent />;
    }
    return (
        <Grid stackable  >
            <Grid.Column stretched mobile={16} tablet={8} computer={5}>
                <CompanyDetailsMain company={company} />
            </Grid.Column>
            <Grid.Column stretched mobile={16} tablet={8} computer={5}>
                <CompanyDetailsData company={company} />
            </Grid.Column>
            <Grid.Column mobile={16} tablet={8} computer={5}>
                <Button as={Link} to={`/editCompany/user/${user.id}/company/${company.id}`} basic color='blue' content='Edit' />
                <Button as={Link} to={`/users/${user.id}`} basic color='grey' content='Cancel' />
            </Grid.Column>
            <Grid.Column mobile={16} tablet={16} computer={10} >

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