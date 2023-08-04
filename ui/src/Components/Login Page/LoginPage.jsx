import React, { useState } from 'react';
import './LoginPage.css';
import { Link } from 'react-router-dom';

const LoginPage = () => {
  const [email, setEmail] = useState('');
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
    const passwordPattern = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-zA-Z]).{8,}$/;
    return passwordPattern.test(password);
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    // Validate username
    if (!email) {
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

    // If everything is valid, perform the login logic here
    // ...
    // Your login logic goes here

    // Clear error after successful submission
    setError('');
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
              value={email}
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
    </div>
  );
};

export default LoginPage;
