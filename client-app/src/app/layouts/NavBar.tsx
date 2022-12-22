import { createMedia } from "@artsy/fresnel";
import { observer } from "mobx-react-lite";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import { Button, Container, Dropdown, Icon, Menu } from "semantic-ui-react";
import internal from "stream";
import { useStore } from "../stores/store";

const name_id = localStorage.getItem('nameid')


export default observer(function NavBar({ Media }: any) {
    const { userStore: { currentUser, logout } } = useStore();
    const role = localStorage.getItem('role')

    return (
        <>
            <Media at="mobileEnd">
                <Menu inverted fixed='top'>
                    <Container >
                        <Menu.Item as={NavLink} to='/' header>
                            <img src="/assets/logo.svg" alt="logo" color="white" style={{ marginRight: '10px' }} />
                            Bancruptcy Prediction App
                        </Menu.Item>
                        <Menu.Item as={NavLink} to='/mainPage' name='Home' />
                        <Menu.Item as={NavLink} to='/myCompanies' name='My Companies' />
                        {role === "Admin" ? <Menu.Item as={NavLink} to='/users' name='Users' /> : <></>}
                        {/* <Menu.Item as={NavLink} to='/companies' name='Companies' /> */}
                        {/* <Menu.Item>
                        
                    <Button as={NavLink} to='/createUser' positive content='Add User' />
                </Menu.Item> */}
                        <Menu.Item position="right">
                            <Icon className="user" spaced='right' />
                            <Dropdown pointing='top left' text={currentUser?.firstName + ' ' + currentUser?.lastName}>
                                <Dropdown.Menu>
                                    <Dropdown.Item as={Link} to={`/users/${name_id}`} text='My Profile' />
                                    <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                                </Dropdown.Menu>
                            </Dropdown>
                        </Menu.Item>
                    </Container>
                </Menu>
            </Media>
            <Media at="mobile">
                <Menu inverted fixed='top'>
                    <Container >
                        <Dropdown item icon='align justify' simple>
                            <Dropdown.Menu>
                                <Dropdown.Item as={NavLink} to='/' header>
                                    <img src="/assets/logo.png" alt="logo" color="white" style={{ marginRight: '10px' }} />
                                    Bancruptcy Prediction App
                                </Dropdown.Item>
                                <Menu.Item as={NavLink} to='/mainPage' name='Home' />
                                <Menu.Item as={NavLink} to='/myCompanies' name='My Companies' />
                                {role === "Admin" ? <Dropdown.Item as={NavLink} to='/users'  >
                                    Users
                                </Dropdown.Item> : <></>}
                                {/* <Dropdown.Item as={NavLink} to='/companies'  >
                                    Companies
                                </Dropdown.Item> */}
                            </Dropdown.Menu>
                        </Dropdown>
                        <Menu.Item position="right">
                            <Icon className="user" spaced='right' />
                            <Dropdown pointing='top left' text={currentUser?.firstName + ' ' + currentUser?.lastName}>
                                <Dropdown.Menu>
                                    <Dropdown.Item as={Link} to={`/profile/${currentUser?.id}`} text='My Profile' />
                                    <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                                </Dropdown.Menu>
                            </Dropdown>
                        </Menu.Item>
                    </Container>
                </Menu>
            </Media></>
    )
})




// {
//     return (
//         <Menu inverted fixed='top'>
//             <Container>
//                 <Menu.Item header>
//                     <img src="/assets/logo.png" alt="logo">
//                     Bancruptcy Prediction Model
//                 </Menu.Item>
//             </Container>
//         </Menu>
//     )
// }