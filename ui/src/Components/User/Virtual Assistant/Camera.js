import React, { useRef } from 'react';
import Webcam from 'react-webcam';

const videoConstraints = {
  width: 220,
  height: 200,
  facingMode: 'user',
};

const Camera = () => {
  const webcamRef = useRef(null);

  const capture = () => {
    const imageSrc = webcamRef.current.video.getScreenshot();
    // Now you can use the captured imageSrc as needed.
    console.log(imageSrc);
  };

  return (
    <div className="webcam-container">
      <Webcam
        audio={false}
        height={200}
        ref={webcamRef}
        screenshotFormat="image/jpeg"
        width={220}
        videoConstraints={videoConstraints}
      />
      <button onClick={capture}>Capture</button>
    </div>
  );
};

export default Camera;
