import { useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import { Segment, Item, Button, Card, Icon, Table } from "semantic-ui-react";
import LoadingComponent from "../../../app/layouts/loading";
import { Company } from "../../../app/models/company";
import { User } from "../../../app/models/user";
import { useStore } from "../../../app/stores/store";
import userStore from "../../../app/stores/userStore";

interface Props {
    company: Company
}

export default function CompanyDetailsData({ company }: Props) {
    return (
        <Segment.Group >
            <Table celled>
                <Table.Body>
                    <Table.Row>
                        <Table.Cell>
                            Registration Year
                        </Table.Cell>
                        <Table.Cell>{company.registrationYear}</Table.Cell>
                    </Table.Row>
                    <Table.Row>
                        <Table.Cell>
                            Deregistration Year
                        </Table.Cell>
                        <Table.Cell>{company.deregistrationYear + company.registrationYear}</Table.Cell>
                    </Table.Row>
                    <Table.Row>
                        <Table.Cell>
                            Business Sector                            </Table.Cell>
                        <Table.Cell>{company.businessSector === 1 ? "Construction" : "Transport"}</Table.Cell>
                    </Table.Row>
                    <Table.Row>
                        <Table.Cell>
                            Is Bankrupt
                        </Table.Cell>
                        <Table.Cell>{company.isBankrupt === 0 ? "NO" : "Yes"}</Table.Cell>
                    </Table.Row>
                    <Table.Row>
                        <Table.Cell>
                            Bancruptcy Case Start
                        </Table.Cell>
                        <Table.Cell>{company.bankruptcyCaseStartYear + company.registrationYear}</Table.Cell>
                    </Table.Row>
                </Table.Body>
            </Table>
        </Segment.Group>

    )
}