import logo from './logo.svg';
import './App.css';
import Cookie from 'js-cookie'
import HeaderBlock from './components/Header/headerBlock'
import gapi from '@types/gapi'


function App() {
  var authCookie = Cookie.get('auth');
  console.log(authCookie);

  return (
    <div className="App">
      <header className="App-header">
        {authCookie == 'true' &&
          <div>
            <img src={logo} className="App-logo" alt="logo" />
            <p>
              <HeaderBlock name="User"></HeaderBlock>
        Edit <code>src/App.js</code> and save to reload.
      </p>
            <a
              className="App-link"
              href="https://reactjs.org"
              target="_blank"
              rel="noopener noreferrer"
            >
              Learn React
      </a>
          </div>
        }
        {
          (authCookie == 'false' || authCookie == undefined) &&
          <div>
            Please, visit login page
          </div>
        }
      </header>
    </div>
  );
}


export default App;
