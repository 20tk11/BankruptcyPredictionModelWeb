import { observer } from "mobx-react-lite";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import { Button, Container, Menu, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import LoginForm from "../users/LoginForm";
import RegisterForm from "../users/RegisterForm";


export default observer(function HomePage() {
    const { userStore, modalStore } = useStore();
    return (
        <Segment className="footer" inverted textAlign='center' vertical  >
            <Container style={{ margin: '30.4em' }}>
                {/* <h1>Home Page</h1> */}
                {/* <Menu.Item as={NavLink} to='/users' header>
                    <img src="/assets/logo.svg" alt="logo" color="white" style={{ marginRight: '10px' }} />
                    Bancruptcy Prediction App
                </Menu.Item> */}
                {userStore.isLoggedIn ? (
                    <>
                        <Button as={Link} to='/mainPage' size='huge' inverted>
                            Go to User Page
                        </Button>
                    </>
                ) : <>
                    <Button onClick={() => modalStore.openModal(<LoginForm />)} size='huge' inverted>
                        Login
                    </Button>
                    <Button onClick={() => modalStore.openModal(<RegisterForm />)} size='huge' inverted>
                        Register
                    </Button>
                </>}

            </Container>
        </Segment>

    )
})