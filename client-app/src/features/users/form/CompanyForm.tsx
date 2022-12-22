import { observer } from "mobx-react-lite";
import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Button, DropdownProps, Form, Message, Segment } from "semantic-ui-react";
import LoadingComponent from "../../../app/layouts/loading";
import { User } from "../../../app/models/user";
import { useStore } from "../../../app/stores/store";
import { v4 as uuid } from 'uuid';
import { Company } from "../../../app/models/company";
const options = [
    { key: 1, text: 'Construction', value: 1 },
    { key: 2, text: 'Transport', value: 2 },
]
const options1 = [
    { key: 0, text: 'Not Bankrupt', value: 0 },
    { key: 1, text: 'Bankrupt', value: 1 },
]
export default observer(
    function CompanyForm() {
        const { companyStore } = useStore();
        const { createCompany, updateCompany, loading, loadCompany, loadingInitial } = companyStore;

        const { id, companyId } = useParams();
        const navigate = useNavigate();

        const [company, setCompany] = useState<Company>({
            id: '',
            jarcode: '',
            name: '',
            registrationYear: 2010,
            deregistrationYear: 5,
            businessSector: 1,
            isBankrupt: 0,
            bankruptcyCaseStartYear: 0,
        });

        useEffect(() => {
            if (companyId && id) {
                loadCompany(id, companyId).then(company => setCompany(company!))

            }
        }, [companyId, loadCompany, loadingInitial, id])

        function handleSubmit() {
            console.log(company.id)
            if (!company.id) {
                if (id) {
                    company.id = uuid();
                    createCompany(id, company).then(() => navigate(`/users/${id}/companies/${company.id}`))
                }
            }
            else {
                if (id) {
                    console.log(company);
                    updateCompany(id, company).then(() => navigate(`/users/${id}/companies/${company.id}`))
                }
            }
        }
        function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
            const { name, value } = event.target;
            setCompany({ ...company, [name]: value });
        }
        function handleInputChangederegistration(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
            const { name, value } = event.target;
            setCompany({ ...company, [name]: value });
            setCompany({ ...company, deregistrationYear: Number(value) - company.registrationYear });

        }
        function handleInputChangedCaseStart(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
            const { name, value } = event.target;
            setCompany({ ...company, [name]: value });
            setCompany({ ...company, bankruptcyCaseStartYear: Number(value) - company.registrationYear });

        }
        function handleSelectChange(event: SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
            const value = data.value;
            setCompany({ ...company, businessSector: Number(value) })
        }
        function handleSelectChangeBankrupt(event: SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
            const value = data.value;
            setCompany({ ...company, isBankrupt: Number(value) })
        }
        // function handleSelectChange(event: SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
        //     const value = data.value;
        //     if (typeof (value) === 'string') {
        //         setCompany({ ...company, role: value })
        //     }

        // }
        console.log('dasfas', Number(company.bankruptcyCaseStartYear) + Number(company.registrationYear))
        console.log('dasfas1', Number(company.registrationYear))
        console.log('dasfas2', Number(company.bankruptcyCaseStartYear))

        if (loadingInitial) {
            return <LoadingComponent content="Loading user" />
        }
        return (
            <Segment clearing>
                <Form onSubmit={handleSubmit} autoComplete="off">
                    <Form.Group widths='equal'>
                        <Form.Input required label="Company Name" placeholder={'Company Name'} value={company.name} name="name" onChange={handleInputChange} />
                        <Form.Input required label="JARCODE" placeholder={'JARCODE'} value={company.jarcode} name="jarcode" onChange={handleInputChange} />
                        <Form.Input type="number" required label="Registration Year" placeholder={'Registration Year'} value={company.registrationYear} name="registrationYear" onChange={handleInputChange} />
                        <Form.Input min={company.registrationYear} type="number" required label="Deregistration Year" placeholder={'Deregistration Year'} value={Number(company.deregistrationYear) + Number(company.registrationYear)} name="registrationYear" onChange={handleInputChangederegistration} />
                    </Form.Group>
                    <Form.Group widths='equal'>
                        <Form.Select label="Business Sector" fluid options={options} placeholder={'Business Sector'} value={company.businessSector} onChange={handleSelectChange} required />
                        <Form.Select label="Is Bankrupt" fluid options={options1} placeholder={'Is Bankrupt'} value={company.isBankrupt} onChange={handleSelectChangeBankrupt} required />
                        <Form.Input min={company.registrationYear} max={Number(company.deregistrationYear) + Number(company.registrationYear)} type="number" required label="Bankruptcy Case Start Year" placeholder={'Bankruptcy Case Start Year'} value={Number(company.bankruptcyCaseStartYear) + Number(company.registrationYear)} name="bankruptcyCaseStartYear" onChange={handleInputChangedCaseStart} />


                    </Form.Group>





                    <Button loading={loading} floated='right' positive type='submit' content='Submit' />
                    {companyId === undefined ? <Button as={Link} to={`/users/${id}`} floated='right' type='submit' content='Cancel' />
                    : <Button as={Link} to={`/users/${id}/companies/${companyId}`} floated='right' type='submit' content='Cancel' />
                    }
                </Form>
            </Segment >
        )
    }
)