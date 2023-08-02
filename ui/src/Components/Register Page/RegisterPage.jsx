import React, { useState } from 'react';
import './RegisterPage.css';

const RegisterPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [username, setUsername] = useState('');
  const [selectedOption, setSelectedOption] = useState(null); // State for radio button

  const [error, setError] = useState('');

  const handleUsernameChange = (event) => {
    setUsername(event.target.value);
  };

  const handleEmailChange = (event) => {
    setEmail(event.target.value);
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };

  const handleOptionChange = (event) => {
    setSelectedOption(event.target.value);
  };

  const validatePassword = (password) => {
    // Use regex to validate the password
    const passwordPattern = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-zA-Z]).{8,}$/;
    return passwordPattern.test(password);
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    // Validate username
    if (!username) {
      setError('Username is required');
      return;
    }

    // Validate email
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

    // Validate radio button (Traveler or Agent)
    if (!selectedOption) {
      setError('Please select an option (Traveler or Agent)');
      return;
    }

    // If everything is valid, perform the registration logic here
    // ...
    // Your registration logic goes here

    // Clear error after successful submission
    setError('');
  };

  return (
    <div className='loginBody'>
      <div className='loginForm'>
        <h1 className='loginHead'>Register</h1>
        <form onSubmit={handleSubmit}>
          <div className='form__group field'>
            <input
              type='text'
              className='form__field'
              placeholder='Name'
              value={username}
              onChange={handleUsernameChange}
              required
            />
            <label htmlFor='name' className='form__label'>
              Username
            </label>
          </div>
          <br />
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
          <div className='MyDict'>
            <div>
              <label>
                <input
                  type='radio'
                  name='radio'
                  value='Traveler'
                  checked={selectedOption === 'Traveler'}
                  onChange={handleOptionChange}
                />
                <span>Traveler</span>
              </label>

              <label>
                <input
                  type='radio'
                  name='radio'
                  value='Agent'
                  checked={selectedOption === 'Agent'}
                  onChange={handleOptionChange}
                />
                <span>Agent</span>
              </label>
            </div>
          </div>
          <br />
          <br />
          <button type='submit' className='ui-btn'>
            <span>Sign Up</span>
          </button>
          <br />
          <br />
          <p className='registerPara'>
            Already Have an account ? &emsp;<a className='registerButton'>Sign In!</a>
          </p>
          {error && <p className='error'>{error}</p>}
        </form>
      </div>
    </div>
  );
};

export default RegisterPage;
