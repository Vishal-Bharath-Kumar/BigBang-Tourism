import React from 'react';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import PhoneInput from 'react-phone-input-2';
import 'react-phone-input-2/lib/style.css';
import OtpInput from 'otp-input-react';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { auth } from './firebase.config';
import { RecaptchaVerifier } from 'firebase/auth';
import { signInWithPhoneNumber,signOut } from 'firebase/auth';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: 'none',
  borderRadius:3,
  boxShadow: 24,
  p: 4,
};

const OtpVerify = ({ open, onClose }) => {
  const [otp, setOtp] = React.useState('');
  const [ph, setPh] = React.useState('');
  const [showOtp, setShowOtp] = React.useState(false);
  const [toastShown, setToastShown] = React.useState(false);
  const [toastShown1, setToastShown1] = React.useState(false);


  function onCaptchaVerify() {
    if (!window.recaptchaVerifier) {
      window.recaptchaVerifier = new RecaptchaVerifier(auth,'recaptcha-container', {
        size: 'invisible',
        callback: (response) => {
          onSignUp();
        },
        'expired-callback': () => {
          // Response expired. Ask user to solve reCAPTCHA again.
          // ...
        },
      });
    }
  }

  function onSignUp() {
    onCaptchaVerify();

    const appVerifier = window.recaptchaVerifier;

    const formatPh = '+' + ph;

    signInWithPhoneNumber(auth, formatPh, appVerifier)
      .then((confirmationResult) => {
        // SMS sent. Prompt user to type the code from the message, then sign the
        // user in with confirmationResult.confirm(code).
        window.confirmationResult = confirmationResult;
        setShowOtp(true);
        if (!toastShown) {
            toast.success('OTP Sent Successfully!', {
              position: 'top-center',
            });
            setToastShown(true);
          }
        // ...
      })
      .catch((error) => {
        // Error; SMS not sent
        console.log(error);
      });
  }

  function onOtpVerify() {
    window.confirmationResult
      .confirm(otp)
      .then(async (res) => {
        console.log(res);
        if (!toastShown1) {
            toast.success('OTP Verified Successfully!', {
              position: 'top-center',
            });
            setToastShown1(true);
            onOtpVerified();
          }

      })
      .catch((error) => {
        // Error; Invalid OTP
        console.log(error);
        if (!toastShown1) {
            toast.error('OTP Invalid!', {
              position: 'top-center',
            });
            setToastShown1(true);
          }
      });
  }
  
  function onOtpVerified() {
    // Close the modal and reset state variables
    onClose();
    setOtp('');
    setPh('');
    setShowOtp(false);
    setToastShown(false);
    setToastShown1(false);
    // Remove user credentials
    signOut(auth)
      .then(() => {
        console.log('User signed out successfully.');
      })
      .catch((error) => {
        console.log('Error signing out:', error);
      });
  }

  return (
    <div>
      <Modal
        open={open}
        onClose={onClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <div id="recaptcha-container"></div>
          <h1 className="typing">Verification</h1>
          {showOtp ? (
            <>
              <div>
                <label htmlFor="otp">Enter Your OTP</label>
                <br />
                <OtpInput
                  value={otp}
                  onChange={setOtp}
                  OTPLength={6}
                  otpType="number"
                  disabled={false}
                  autoFocus
                  className="otpInput"
                ></OtpInput>
                <br />
                <button onClick={onOtpVerify} className="formButton">
                  Verify OTP
                </button>
              </div>
            </>
          ) : (
            <>
              <div>
                <label htmlFor="">Enter Your Phone Number</label>
                <br />
                <PhoneInput
                  country={'in'}
                  value={ph}
                  onChange={setPh}
                ></PhoneInput>
                <br />
                <button onClick={onSignUp} className="formButton">
                  Send Code via SMS
                </button>
              </div>
            </>
          )}

          <ToastContainer autoClose={2000} pauseOnHover />
        </Box>
      </Modal>
    </div>
  );
};

export default OtpVerify;
