import React, { Component } from 'react';
// import logo from './logo.svg';
import './App.css';
import AuthService from './services/AuthService';
import { Switch, Route } from 'react-router-dom';
import Home from './components/Home'

class App extends Component {
  constructor() {
    super();
    this.authService = new AuthService();
  }


  renderHome() {
    console.log("RenderHome");
    let resultComponet = <Home auth= { this.authService }/>;
    if (!this.authService.isAuthenticated()) {
      this.authService.login();
      resultComponet = <div><p>Redirecting to the authenticantion service...</p></div>;
    }
    return resultComponet;
  }

  startSession(history) {
    console.log("startSession");
    this.authService.handleAuthentication(history);
    return <div><p>Starting session...</p></div>;
  }

  createLogoutButton() {
    let button = null;

    if(this.authService.isAuthenticated()) {
      button = <button onClick ={() => this.authService.logout()}>Logout</button>;
    }
    return button;
  }

  render() {
    let logoutButton = this.createLogoutButton();

    return (
      <div className="App">
        <header className="App-header">
          { logoutButton }
          <h1 className="App-title">My Bookstore</h1>
        </header>
        <Switch>
          <Route exact path="/" render = {() => this.renderHome()}/>
          <Route path="/startSession" render = {({history}) => this.startSession(history)}/>
        </Switch>
      </div>
    );
  }
}

export default App;
