import React, { useState } from 'react';
import './LoginPage.css';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { toast, ToastContainer } from 'react-toastify';
import jwt_decode from 'jwt-decode';

const LoginPage = () => {
  const [emailId, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleEmailChange = (event) => {
    setEmail(event.target.value);
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };

  const validatePassword = (password) => {
    // Use regex to validate the password
    const passwordPattern = /^(?=.*\d)(?=.*[a-zA-Z]).{8,}$/;
    return passwordPattern.test(password);
  };

  const navigate = useNavigate();

  const handleSubmit =async (event) => {
    event.preventDefault();

    try {
      console.log(emailId,password);
      const response = await axios.post('https://localhost:7204/api/User/login', {emailId,password});

      if (response.status === 200) {
        const token = response.data;
        localStorage.setItem('token', token);

        const decodedToken = jwt_decode(token);
        console.log('Token:', token);
        console.log('Email Id:', emailId);
        console.log('Role:', decodedToken.role);
        console.log('nameid', decodedToken.nameid);
        localStorage.setItem('nameid', decodedToken.nameid);
        if (decodedToken.role === "Administrator") {
          toast.success('Admin Login Successful');
          navigate('/AdminDashboard');
        }
        else if(decodedToken.role === "TravelAgent"){
          toast.success('Agent Login Successful');
           navigate("/AgentHome");
        }
        else if(decodedToken.role === "Traveler"){
          toast.success('User Login Successful');
          navigate("/");
        }
        else{
          toast.danger('Invalid Credentials');
        }
       

      } else {
        console.error('Error during login:', response);
        toast.error('Invalid Credentials');
      }
    } catch (error) {
      console.error('Error during login:', error);
      toast.error('Invalid Credentials');
    }
  

    // Validate username
    if (!emailId) {
      setError('Email is required');
      return;
    }

    // Validate password
    if (!password) {
      setError('Password is required');
      return;
    }

    if (!validatePassword(password)) {
      setError(
        'Password must have 1 number, 1 special character, and at least 8 characters'
      );
      return;
    }
  
  };

  return (
    <div className='loginBody'>
      <div className='loginForm'>
        <h1 className='loginHead'>LOGIN</h1>
        <form onSubmit={handleSubmit}>
          <div className='form__group field'>
            <input
              type='email'
              className='form__field'
              placeholder='Name'
              value={emailId}
              onChange={handleEmailChange}
              required
            />
            <label htmlFor='name' className='form__label'>
              Email Id
            </label>
          </div>
          <br />
          <div className='form__group field'>
            <input
              type='password'
              className='form__field'
              placeholder='Password'
              value={password}
              onChange={handlePasswordChange}
              required
            />
            <label htmlFor='password' className='form__label'>
              Password
            </label>
          </div>
          <br />
          <br />
          {error && <p className='error'>{error}</p>}
          <br />
          <button type='submit' className='ui-btn'>
            <span>Sign In</span>
          </button>
          <br />
          <br />
          <p className='registerPara'>
            Haven't an account ? &emsp;
            <Link to='/SignUp' className='registerButton'>
              Register Now!
            </Link>
          </p>
          
        </form>
      </div>
      <ToastContainer />
    </div>
  );
};

export default LoginPage;
