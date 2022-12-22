import { Button, Grid, Item } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import LoadingComponent from "../../../app/layouts/loading";
import { NavLink } from "react-router-dom";
import CompanyList from "./CompanyList";
import { User } from "../../../app/models/user";

const name_id = localStorage.getItem('nameid')



export default observer(function MyCompanies() {
    const { companyStore, userStore } = useStore();
    const { companyRegistry, loadCompanies } = companyStore;
    const { selectedUser, loadUser } = userStore;
    const [loggedInUser, setLoggedInUser] = useState<User>();
    useEffect(() => {
        loadCompanies(name_id!);
        console.log(companyRegistry);




        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [loadCompanies, companyRegistry.size])


    if (companyStore.loadingInitial) return <LoadingComponent content='Loading Bancruptcy Prediction App' />
    return (
        <Grid>
            <Grid.Column >
                <Item.Header style={{ marginBottom: "35px" }}>My Companies
                    <Button as={NavLink} to={`/createCompany/user/${name_id}`} positive content='Add Company' floated="right" />
                </Item.Header >
                <CompanyList />
            </Grid.Column>
        </Grid>
    )
})