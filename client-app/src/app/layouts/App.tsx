import React, { Fragment, useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import { Outlet, useLocation } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import HomePage from '../../features/home/HomePage';
import { useStore } from '../stores/store';
import UserStore from '../stores/userStore';
import LoadingComponent from './loading';
import ModalContainer from '../common/form/ModalContainer';
import { createMedia } from '@artsy/fresnel';
import Footer from './footer';
const AppMedia = createMedia({
  breakpoints: {
    mobile: 0,
    mobileEnd: 720,

  }
});
const mediaStyles = AppMedia.createMediaStyle();
const { Media, MediaContextProvider } = AppMedia;

function App() {
  const location = useLocation();
  const { commonStore, userStore } = useStore();
  let role: string = '';
  let nameid: string = '';
  const token = localStorage.getItem('jwt')
  if (token) {
    role = JSON.parse(atob(token.split('.')[1]))["role"]
    nameid = JSON.parse(atob(token.split('.')[1]))["nameid"]
  }
  localStorage.setItem('role', role);
  localStorage.setItem('nameid', nameid);
  useEffect(() => {
    if (commonStore.token) {
      userStore.userGetter().finally(() => commonStore.setAppLoaded())
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore])
  if (!commonStore.appLoaded) return <LoadingComponent content='Loading app' />
  return (

    <Fragment>
      <style>{mediaStyles}</style>
      <ModalContainer />
      {location.pathname === '/' ? <HomePage /> : (
        <>
          <MediaContextProvider>
            <NavBar Media={Media} />
          </MediaContextProvider>
          <Container style={{ marginTop: '7em' }}>
            <Outlet />
          </Container>
          <Footer />
        </>
      )}
    </Fragment>
  );
}

export default observer(App);
