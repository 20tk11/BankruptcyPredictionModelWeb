import { observer } from "mobx-react-lite";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import { Button, Container, Menu, Segment, Image } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import LoginForm from "../users/LoginForm";
import RegisterForm from "../users/RegisterForm";


export default observer(function MainPage() {
    return (
        <Container style={{ margin: '30.4em' }}>
            <Image src='/assets/logo.png' fluid />
        </Container>

    )
})