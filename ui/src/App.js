
import './App.css';
import { BrowserRouter,Routes,Route } from 'react-router-dom';
import UserHome from './Components/User/User Home/UserHome';
import LoginPage from './Components/Login Page/LoginPage';
import RegisterPage from './Components/Register Page/RegisterPage';
import NotFound from './Components/404 Page/NotFound';
import TodoList from './Components/User/TodoList/TodoList';
import AdminDashboard from './Components/Admin/Admin Dashboard/AdminDashboard';
import AdminGallery from './Components/Admin/Admin Gallery/AdminGallery';
import UserPackages from './Components/User/User Packages/UserPackages';
import AgentHome from './Components/Travel Agent/Agent Home/AgentHome';
import Main from './Components/User/Virtual Assistant/Main';

function App() {
  return (
    <div className="App">
      
     <BrowserRouter>
     <Routes>
      <Route path='/' Component={UserHome}></Route>
      <Route path='/TodoList' Component={TodoList}></Route>
      <Route path='Main' Component={Main}></Route>
      <Route path='/Packages' Component={UserPackages}></Route>
      <Route path='/Login' Component={LoginPage}></Route>
      <Route path='/SignUp' Component={RegisterPage}></Route>
      <Route path='/NotFound' Component={NotFound}></Route>
      <Route path='/AdminDashboard'  Component={AdminDashboard}></Route>
      <Route path='/AdminGallery' Component={AdminGallery}></Route>
      <Route path= '/AgentHome' Component={AgentHome}></Route>
     </Routes>
     </BrowserRouter>
      
    </div>
  );
}

export default App;
