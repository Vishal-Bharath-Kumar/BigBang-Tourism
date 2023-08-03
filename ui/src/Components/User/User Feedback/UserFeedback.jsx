import React ,{useRef}from 'react'
import emailjs from '@emailjs/browser';
import './UserFeedback.css'

const UserFeedback = () => {
   
    const form = useRef();

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs.sendForm(
        'service_updw4cq', 
        'template_418pqmv',
        form.current, 
        'IkWbOj8hUcy1g8AWr'
        )
      .then((result) => {
          console.log(result.text);
      }, (error) => {
          console.log(error.text);
      });
    }
  return (
    <div className='feedbackForm'>
        <h1 className='cardHeading'>Share Your Feedback with Us!</h1>
        <form ref={form} onSubmit={sendEmail}>
        <label >Name</label>
        <input type="text" name="user_name" />
        <label >Email</label>
        <input  type="email" name="user_email" />
        <label >Message</label>
        <textarea name="message" />
        <input type="submit" value="Send" />
        </form>
    </div>
  )
}

export default UserFeedback