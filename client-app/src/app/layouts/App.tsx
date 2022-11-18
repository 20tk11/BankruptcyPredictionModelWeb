import React, { Fragment, useEffect, useState } from 'react';
import { Container, Header, List } from 'semantic-ui-react';
import NavBar from './NavBar';
import UserDashboard from '../../features/users/dashboard/UserDasgboard';
import { Route, Routes } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';

function App() {
  

  return (
    <Fragment>
      <NavBar/>
      <Container style={{marginTop:'7em'}}>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/users' element={<UserDashboard />} />
        </Routes>
      </Container>
    </Fragment>
  );
}

export default App;
