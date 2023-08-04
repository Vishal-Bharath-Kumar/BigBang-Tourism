
import './App.css';
import { BrowserRouter,Routes,Route } from 'react-router-dom';
import UserHome from './Components/User/User Home/UserHome';
import LoginPage from './Components/Login Page/LoginPage';
import RegisterPage from './Components/Register Page/RegisterPage';
import NotFound from './Components/404 Page/NotFound';
import TodoList from './Components/User/TodoList/TodoList';

function App() {
  return (
    <div className="App">
      
     <BrowserRouter>
     <Routes>
      <Route path='/'  Component={UserHome}></Route>
      <Route path='/TodoList' Component={TodoList}></Route>
      <Route path='/Login' Component={LoginPage}></Route>
      <Route path='/SignUp' Component={RegisterPage}></Route>
      <Route path='/NotFound' Component={NotFound}></Route>
     </Routes>
     </BrowserRouter>
      
    </div>
  );
}

export default App;
