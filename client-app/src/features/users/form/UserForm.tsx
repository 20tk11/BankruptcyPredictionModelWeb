import { observer } from "mobx-react-lite";
import React, { ChangeEvent, SyntheticEvent, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Button, DropdownProps, Form, Segment } from "semantic-ui-react";
import LoadingComponent from "../../../app/layouts/loading";
import { User } from "../../../app/models/user";
import { useStore } from "../../../app/stores/store";
import { v4 as uuid } from 'uuid';

const options = [
    { key: 'Admin0', text: 'Admin', value: 'Admin' },
    { key: 'User', text: 'User', value: 'User' },
]


export default observer(
    function UserForm() {
        const { userStore } = useStore();
        const { createUser, updateUser, loading, loadUser, loadingInitial } = userStore;

        const { id } = useParams();
        const navigate = useNavigate();
        const [user, setUser] = useState<User>({
            id: '',
            firstName: '',
            lastName: '',
            email: '',
            userName: '',
            phoneNumber: '',
            country: '',
            city: '',
            organization: '',
            role: '',
            token: '',
        });

        useEffect(() => {
            if (id) loadUser(id).then(user => setUser(user!))
        }, [id, loadUser])

        function handleSubmit() {
            if (!user.id) {
                user.id = uuid();
                createUser(user).then(() => navigate(`/users/${user.id}`))
            }
            else {
                updateUser(user).then(() => navigate(`/users/${user.id}`))
            }
        }
        function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) {
            const { name, value } = event.target;
            setUser({ ...user, [name]: value })
        }
        function handleSelectChange(event: SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
            const value = data.value;
            if (typeof (value) === 'string') {
                setUser({ ...user, role: value })
            }

        }
        if (loadingInitial) return <LoadingComponent content="Loading user" />
        return (
            <Segment clearing>
                <Form onSubmit={handleSubmit} autoComplete="off">
                    <Form.Input required label="First Name" placeholder={'First Name'} value={user.firstName} name="firstName" onChange={handleInputChange} />
                    <Form.Input required label="Last Name" placeholder={'Last Name'} value={user.lastName} name="lastName" onChange={handleInputChange} />

                    <Form.Input required label="Email Adress" placeholder={'Email Address'} value={user.email} name="email" onChange={handleInputChange} />
                    <Form.Input required label="Login Name" placeholder={'Login Name'} value={user.userName} name="userName" onChange={handleInputChange} />
                    <Form.Input label="Phone Number" placeholder={'Phone Number'} value={user.phoneNumber} name="phoneNumber" onChange={handleInputChange} />
                    <Form.Input label="Organization" placeholder={'Organization'} value={user.organization} name="organization" onChange={handleInputChange} />
                    <Form.Input label="Country" placeholder={'Country'} value={user.country} name="country" onChange={handleInputChange} />
                    <Form.Input label="City" placeholder={'City'} value={user.city} name="city" onChange={handleInputChange} />
                    <Form.Select label="Role" fluid options={options} placeholder={'Role'} value={user.role} onChange={handleSelectChange} required />
                    <Button loading={loading} floated='right' positive type='submit' content='Submit' />
                    <Button as={Link} to={'/users'} floated='right' type='submit' content='Cancel' />
                </Form>
            </Segment>
        )
    }
)