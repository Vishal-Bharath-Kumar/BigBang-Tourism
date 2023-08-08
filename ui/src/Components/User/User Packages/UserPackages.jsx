import React,{useEffect, useState} from 'react'
import UserNavbar from '../User Navbar/UserNavbar';
import BookingForm from "../Booking Form/BookingForm";
import './UserPackages.css'
import Rating from '@mui/material/Rating';
import UserFooter from '../User Footer/UserFooter';
import axios from 'axios';


const UserPackages = () => {
  const [data, setData] = useState([]);
    const [isBookingDrawerOpen, setIsBookingDrawerOpen] = useState(false);

        const handleBookingDrawerOpen = () => {
          setIsBookingDrawerOpen(true);
        };

        const handleBookingDrawerClose = () => {
          setIsBookingDrawerOpen(false);
        };


        useEffect(() => {
          // This function will be called when the component mounts and every time it updates
          fetchData();
          console.log(data);
          // This function will be called when the component unmounts or when the dependency array changes
         
        }, []);

        const fetchData = async () => {
          try {
            const response = await axios.get('https://localhost:7204/api/Tour');
            setData(response.data);
          } catch (error) {
            console.error('Error fetching data:', error);
          }
        };
  return (
    <>
    <div>
        <UserNavbar />
        <div className="starterHome">
        <h1 className="posterHead">World Class Travel</h1>
        <button className="bookButton" onClick={handleBookingDrawerOpen}>Book Now</button>
        {isBookingDrawerOpen && <BookingForm onClose={handleBookingDrawerClose} />}
        <br />
        <br />
        <br />
        <br />
        <h1 className='typing'>Must Visit Destinations</h1>
        <div className='PackageCards'>
        {data.map(item => (
            <div key={item.tourName}> {/* Wrap each mapped item in a container */}
              <li>{item.tourName}</li>
              <li>
                <img  
                  src={`data:image/jpeg;base64,${item.TourImageUrl}`}
                  alt={`Image for ${item.tourName}`}
                />
              </li>
            </div>
          ))}
        <div className="movie-card">
        <div className="content-card">
        
            <img src="https://pad.mymovies.it/filmclub/2017/11/159/locandina.jpg" />
            <span className="shadow"></span>
            <div className="content">
            <h1>aladdin</h1>
            <p className="date">2019 . guy ritche</p>
            <b>2h 10m</b>
            <div className="stars">
            <Rating name="read-only" value={2} readOnly />
            </div>
            <div className="hex-tag">
                <div className="tag">
                #action
                </div>
                <div className="tag">
                #romantic
                </div>
                <div className="tag">
                #family
                </div>
            </div>
            </div>
        </div>
        </div>
        </div>
        <br />
        <br />
        <br />
        <h1 className='typing'>Top Notch Hotels</h1>
        <div className='PackageCards'>
        <div className="movie-card">
        <div className="content-card">
            <img src="https://pad.mymovies.it/filmclub/2017/11/159/locandina.jpg" />
            <span className="shadow"></span>
            <div className="content">
            <h1>aladdin</h1>
            <p className="date">2019 . guy ritche</p>
            <b>2h 10m</b>
            <div className="stars">
            <Rating name="read-only" value={2} readOnly />
            </div>
          <div className="hex-tag">
                <div className="tag">
                #action
                </div>
                <div className="tag">
                #romantic
                </div>
                <div className="tag">
                #family
                </div>
            </div>
            </div>
        </div>
        </div>
        </div>
    </div>
    </div>
    </>
    
  )
}

export default UserPackages