import { Button, Grid, Item } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import LoadingComponent from "../../../app/layouts/loading";
import { NavLink } from "react-router-dom";
import CompanyList from "./CompanyList";



export default observer(function CompanyDashboard() {
    const { companyStore, userStore } = useStore();
    const { companyRegistry, loadCompanies } = companyStore;
    const { selectedUser } = userStore;

    useEffect(() => {
        if (selectedUser) {
            companyStore.loadCompanies(selectedUser.id);
        }




        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [loadCompanies, companyRegistry.size])


    if (companyStore.loadingInitial) return <LoadingComponent content='Loading Bancruptcy Prediction App' />
    return (
        <Grid>
            <Grid.Column >

                <CompanyList />
            </Grid.Column>
        </Grid>
    )
})