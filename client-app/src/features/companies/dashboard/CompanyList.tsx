import { observer } from "mobx-react-lite";
import React, { Fragment, SyntheticEvent, useState } from "react";
import { Link } from "react-router-dom";
import { Button, Header, Item, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import CompanyListItem from "./CompanyListItem";


export default observer(function CompanyList() {


    const { companyStore } = useStore();
    const { companiesByLastName } = companyStore;
    console.log(companiesByLastName);
    // const temp = groupedUsers[0];
    // groupedUsers[0] = groupedUsers[1];
    // groupedUsers[1] = temp;
    return (
        <Fragment >
            <Item.Group divided >
                {companiesByLastName.map(company => (
                    <CompanyListItem key={company.id} company={company} />
                ))}
            </Item.Group>
        </Fragment>




    )
})