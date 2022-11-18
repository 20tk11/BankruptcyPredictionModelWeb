import React from "react";
import { NavLink } from "react-router-dom";
import { Button, Container, Menu } from "semantic-ui-react";

export default function NavBar() {
    return (
        <Menu inverted fixed='top'>
            <Container >
                <Menu.Item as={NavLink} to='/' header>
                    <img src="/assets/logo.svg" alt="logo" color = "white" style={{marginRight: '10px'}}/>
                    Bancruptcy Prediction App
                </Menu.Item>
                <Menu.Item as={NavLink} to='/users' name='Users'/>
                <Menu.Item>
                    <Button positive content='Add User' />
                </Menu.Item>
            </Container>
        </Menu>
    )
}




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