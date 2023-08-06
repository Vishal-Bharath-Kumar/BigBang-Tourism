// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAuth } from "firebase/auth";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  
  apiKey: "AIzaSyC0ysRFqQiDN_CCSnYdYiohN8lCfUcyA-U",
  authDomain: "otp-project-31dbd.firebaseapp.com",
  projectId: "otp-project-31dbd",
  storageBucket: "otp-project-31dbd.appspot.com",
  messagingSenderId: "192817659069",
  appId: "1:192817659069:web:a7e873235ebce3264a4bd4",
  measurementId: "G-5QYYS9RNY4"
  
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
export const auth = getAuth(app);
auth.appVerificationDisabledForTesting = true;