import React from 'react';
import Bot from './Bot';
import './Main.css';
import SpeechRecognition, { useSpeechRecognition } from 'react-speech-recognition';


const Main = () => {

  const commands =[
    {
      command: 'clear',
      callback:({resetTranscript}) => resetTranscript()
    },
    {
      command: 'open *',
      callback:(site) =>{
        window.open('https://'+site+'.com')
      }
    },
      {
        command: 'go to kanini website',
        callback:() =>{
          window.open('https://kanini.com/')
        }
    },
    {
      command: 'search *',
      callback: (q) =>{
        window.open('http://google.com/search?q='+q)
      }
    },
    {
      command: 'play song',
      callback: () =>{
      var audio = new Audio('music/song.mp3');
        audio.play();
      }
    },
    {
      command: 'hi',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = "Welcome, back!";
      }
    },
    {
      command: 'hello',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = "Hi";
      }
    },
    {
      command: 'What is your name',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = "Spark";
      }
    },
    {
      command: 'I love you',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = "Love you too";
      }
    },
    {
      command: 'who is your *',
      callback: (owner)=>{
        document.getElementById("talkbubble").innerHTML = 'My '+owner+' name is Vishal';
      }
    },
    {
      command: 'refresh',
      callback: ()=>{
        window.location.reload();
      }
    },
    {
      command: 'you are',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = 'Thank u :)';
      }
    },
    {
      command: 'How are you',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = 'Fine, what about you?';
      }
    },
    {
      command: 'What are some popular tourist destinations in India',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = 'Some popular tourist destinations in India are Taj Mahal, Goa, Kerala, Jaipur, and Ladakh';
      }
    },
    {
      command: 'How can I book accommodation in India',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = 'You can book Hotels through our website';
      }
    },
    {
      command: 'fine',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = 'Nice to hear it';
      }
    },
    {
      command: 'What are some adventure activities available in India',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = 'India offers a wide range of adventure activities like trekking in the Himalayas, river rafting in Rishikesh, and camel safari in Rajasthan';
      }
    },
    {
      command: 'How can i contact you',
      callback: ()=>{
        document.getElementById("talkbubble").innerHTML = 'You can reach out us via sparktourism@gmail.com';
      }
    },
    {
      command: 'camera',
      callback: ()=>{
        window.open('/Camera')
      }
    }

  ]
  const {
    transcript,
    listening,
    resetTranscript,
    browserSupportsSpeechRecognition
  } = useSpeechRecognition({commands});

  if (!browserSupportsSpeechRecognition) {
    return <span>Browser doesn't support speech recognition.</span>;
  }

  return (
    <div className='container12'>
      <span className={listening ? 'on' : 'off'}></span>
      <div className="botButtons">
      <button onClick={SpeechRecognition.startListening({continuous: true})}>Start</button>
      <button onClick={SpeechRecognition.stopListening}>Stop</button>
      <button onClick={resetTranscript}>Reset</button>
      </div>
      <Bot />
      <div className="bubbleContainer">
      <div id="talkbubble">
      </div>
      </div>
      <div className="subtitle">
      <p className='para'>{transcript}</p>
      </div>
      </div>
  );
};
export default Main;