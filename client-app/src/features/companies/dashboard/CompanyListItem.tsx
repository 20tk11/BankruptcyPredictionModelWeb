import { SyntheticEvent, useState } from "react"
import { Link } from "react-router-dom"
import { Item, Button, Label, Segment } from "semantic-ui-react"
import loading from "../../../app/layouts/loading"
import { Company } from "../../../app/models/company"
import { User } from "../../../app/models/user"
import { useStore } from "../../../app/stores/store"
const name_id = localStorage.getItem('nameid')


interface Props {
    company: Company
}

export default function UserListItem({ company }: Props) {
    const { userStore, companyStore } = useStore();
    const { selectedUser } = userStore;
    const { deleteCompany, loading, selectedCompany } = companyStore;
    const [target, setTarget] = useState('');

    function handleUserDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        deleteCompany(id);


    }
    return (

        <Segment.Group>
            <Segment style={{ marginTop: "0px" }}>
                <Item.Group>
                    <Item className="item-content">
                        <Item.Content verticalAlign="middle" >
                            <Item.Header as={Link} to={`/users/${company.id}`}>
                                {company.name}
                            </Item.Header>
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
            <Segment secondary clearing>
                <Button as={Link} to={`/users/${name_id}/companies/${company.id}`} color='teal' floated='left' content='View' />
                <Button onClick={(e) => handleUserDelete(e, company.id)} color='red' floated='left' content='Delete' />
            </Segment>
        </Segment.Group>
    )
}