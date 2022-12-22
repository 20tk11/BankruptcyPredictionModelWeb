import { Button, Grid, Item } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import { Fragment, useEffect } from "react";
import LoadingComponent from "../../../app/layouts/loading";
import { NavLink } from "react-router-dom";
import CompanyList from "./CompanyList";
import CompaniesDashboard from "./CompaniesDashboard";



export default observer(function CurrentCompany() {



    return (
        <Fragment>
            <Item.Header style={{ marginBottom: "35px" }}>My Companies
                <Button as={NavLink} to='/createCompany' positive content='Add Company' floated="right" />
            </Item.Header >
            <CompaniesDashboard />
        </Fragment>
    )
})