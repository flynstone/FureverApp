import React, { Component } from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';
import Profile from './components/Profile';
import AnimalPopUp from './components/AnimalPopUp';
import './custom.css'

const App = () => (
  <Layout>
    {/* <Route exact path='/Login' component={Login} /> */}
    {/* <Route exact path='/Register' component={Register} /> */}
    <Route exact path='/' component={Home} />
    {/* <Route exact path='/Profile' component={} /> */}
  </Layout>
);

export default App;
