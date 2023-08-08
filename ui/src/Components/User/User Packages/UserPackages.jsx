import React,{useEffect, useState} from 'react'
import UserNavbar from '../User Navbar/UserNavbar';
import BookingForm from "../Booking Form/BookingForm";
import './UserPackages.css'
import Rating from '@mui/material/Rating';
import { Card, CardContent, CardMedia, Typography } from '@mui/material';
import axios from 'axios';


const UserPackages = () => {
  const [tourData, setTourData] = useState([]);
  const [hotelData, setHotelData] = useState([]);
  const [isBookingDrawerOpen, setIsBookingDrawerOpen] = useState(false);

  const handleBookingDrawerOpen = () => {
    setIsBookingDrawerOpen(true);
  };

  const handleBookingDrawerClose = () => {
    setIsBookingDrawerOpen(false);
  };

  useEffect(() => {
    fetchTourData();
    fetchHotelData();
  }, []);

  const fetchTourData = async () => {
    try {
      const response = await axios.get('https://localhost:7204/api/Tour');
      setTourData(response.data);
    } catch (error) {
      console.error('Error fetching tour data:', error);
    }
  };

  const fetchHotelData = async () => {
    try {
      const response = await axios.get('https://localhost:7204/api/Hotels'); // Update the hotel API endpoint
      setHotelData(response.data);
    } catch (error) {
      console.error('Error fetching hotel data:', error);
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
        <div className="PackageCards">
            {tourData.map((item, index) => (
              <Card key={index} className="cardPackage" >
                <CardMedia
                  component="img"
                  src={`data:image/jpeg;base64,${item.tourImageUrl}`}
                  alt={`Image for ${item.tourName}`}
                  height={"120px"}
                  width={"72px"}
                />
                <CardContent>
                  <Typography variant="h6" component="h2">
                    {item.tourName}
                  </Typography>
                  <Typography color="textSecondary">{item.tourLocation}</Typography>
                  <Typography color="textSecondary">{item.description}</Typography>
                  <Typography color="textSecondary">
                    Price : {item.tourPrice}
                  </Typography>
                  {/* Add other details here */}
                </CardContent>
              </Card>
            ))}
          </div>
        <h1 className='typing'>Top Notch Hotels</h1>
        <div className="PackageCards">
            {hotelData.map((item, index) => (
              <Card key={index} className="cardPackage" >
                <CardMedia
                  component="img"
                  src={`data:image/jpeg;base64,${item.hotelImageUrl}`}
                  alt={`Image for ${item.hotelName}`}
                  height={"120px"}
                  width={"72px"}
                />
                <CardContent>
                  <Typography variant="h6" component="h2">
                    {item.hotelName}
                  </Typography>
                  <Typography color="textSecondary">{item.address}</Typography>
                  <Typography color="textSecondary">{item.hotelLocation}</Typography>
                  <Typography color="textSecondary">
                    Contact : {item.contactInfo}
                  </Typography>
                  {/* Add other details here */}
                </CardContent>
              </Card>
            ))}
          </div>
    </div>
    </div>
    </>
    
  )
}

export default UserPackages