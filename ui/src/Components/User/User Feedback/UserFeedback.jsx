import React, { useRef, useState, useEffect } from 'react';
import emailjs from '@emailjs/browser';
import './UserFeedback.css';

const UserFeedback = () => {
  const form = useRef();
  const [reloadFlag, setReloadFlag] = useState(false);

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs
      .sendForm('service_updw4cq', 'template_418pqmv', form.current, 'IkWbOj8hUcy1g8AWr')
      .then(
        (result) => {
          console.log(result.text);
          setReloadFlag(true);
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

      // Reload the component after 1 second (adjust the delay as needed)
      setTimeout(() => {
        window.location.reload();
      }, 10);
    }
  }, [reloadFlag]);

  return (
    <div className="feedbackForm">
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
