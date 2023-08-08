import React, { useRef, useState, useEffect } from 'react';
import emailjs from '@emailjs/browser';
import Snackbar from '@mui/material/Snackbar';
import MuiAlert from '@mui/material/Alert';
import './UserFeedback.css';

const UserFeedback = () => {
  const form = useRef();
  const [reloadFlag, setReloadFlag] = useState(false);
  const [showSnackbar, setShowSnackbar] = useState(false); // State to manage the Snackbar

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs
      .sendForm('service_updw4cq', 'template_418pqmv', form.current, 'IkWbOj8hUcy1g8AWr')
      .then(
        (result) => {
          console.log(result.text);
          setReloadFlag(true);
          setShowSnackbar(true); // Show the Snackbar when the email is sent successfully
        },
        (error) => {
          console.log(error.text);
        }
      );
  };

  useEffect(() => {
    if (reloadFlag) {
      // Reset the reloadFlag to false to prevent continuous reloading
      setReloadFlag(false);
    }
  }, [reloadFlag]);

  const handleSnackbarClose = () => {
    setShowSnackbar(false); // Hide the Snackbar when closed
    window.location.reload(); // Reload the component after the Snackbar is closed
  };

  return (
    <div className="feedbackForm">
      <Snackbar open={showSnackbar} autoHideDuration={2000} onClose={handleSnackbarClose}>
        <MuiAlert onClose={handleSnackbarClose} severity="success" sx={{ width: '100%' }}>
          Feedback Sent Successfully
        </MuiAlert>
      </Snackbar>
      <h1 className="cardHeading">Share Your Feedback with Us!</h1>
      <form ref={form} onSubmit={sendEmail}>
        <label>Name</label>
        <input type="text" name="user_name" required />
        <label>Email</label>
        <input type="email" name="user_email" required />
        <label>Message</label>
        <textarea name="message" required />
        <input type="submit" value="Send" />
      </form>
    </div>
  );
};

export default UserFeedback;
