import React, { useRef,  useState, useEffect } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAngleLeft, faAngleRight } from "@fortawesome/free-solid-svg-icons";
import UserNavbar from '../User Navbar/UserNavbar'
import './UserHome.css'
import UserFooter from "../User Footer/UserFooter";
import UserFeedback from "../User Feedback/UserFeedback";

const UserHome = () => {
        //Carousel
        const slideRef = useRef(null);
        const [loadingProgress,] = useState(0);
      
        const handleClickNext = () => {
          let items = slideRef.current.querySelectorAll(".item");
          slideRef.current.appendChild(items[0]);
        };
      
        const handleClickPrev = () => {
          let items = slideRef.current.querySelectorAll(".item");
          slideRef.current.prepend(items[items.length - 1]);
        };
      
        const data = [
          {
            id: 1,
            imgUrl: "https://images.pexels.com/photos/2108845/pexels-photo-2108845.jpeg?auto=compress&cs=tinysrgb&w=800",
            desc: "Life is short and the world is wide. Better get started.",
            name: "SPARK TOURISM",
          },
          {
            id: 2,
            imgUrl:
              "https://images.pexels.com/photos/2474691/pexels-photo-2474691.jpeg?auto=compress&cs=tinysrgb&w=800&lazy=load",
            desc: "Life is not meant to be lived in one place.",
            name: "SPARK TOURISM",
          },
          {
            id: 3,
            imgUrl:
              "https://images.pexels.com/photos/450441/pexels-photo-450441.jpeg?auto=compress&cs=tinysrgb&w=800",
            desc: "An adventure is only an inconvenience rightly considered.",
            name: "SPARK TOURISM",
          },
          {
            id: 5,
            imgUrl: "https://images.pexels.com/photos/2088282/pexels-photo-2088282.jpeg?auto=compress&cs=tinysrgb&w=800",
            desc: "Happiness is not a station you arrive at, but a manner of traveling.",
            name: "SPARK TOURISM",
          },
          {
            id: 6,
            imgUrl:
              "https://images.pexels.com/photos/2249285/pexels-photo-2249285.jpeg?auto=compress&cs=tinysrgb&w=800",
            desc: "Always say yes to new adventures.",
            name: "SPARK TOURISM",
          },
        ];

        
        useEffect(() => {
           const apiKey = "c46dfdf48334608efb1e4dfdbf9a9f10";
      
          const getWeatherByLocation = async (city) => {
            try {
              const response = await fetch(
                `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}`
              );
      
              if (!response.ok) {
                throw new Error("Weather data not found.");
              }
      
              const weatherData = await response.json();
              addWeatherToPage(weatherData);
            } catch (error) {
              console.error("Error fetching weather data:", error);
              // Handle error display or other actions
            }
          };
      
          const main = document.getElementById('main');
          const form = document.getElementById('form');
          const search = document.getElementById('search');
      
          const addWeatherToPage = (data) => {
            const temp = Ktoc(data.main.temp);
            const weather = document.createElement('div');
            weather.classList.add('weather');
            weather.innerHTML = `
              <h2><img src="https://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png" /> ${temp}°C <img src="https://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png" /></h2>
              <small>${data.weather[0].main}</small>
            `;
            // cleanup
            main.innerHTML = "";
            main.appendChild(weather);
          };
      
          const Ktoc = (K) => {
            return Math.floor(K - 273.15);
          };
      
          form.addEventListener('submit', (e) => {
            e.preventDefault();
            const city = search.value;
            if (city) {
              getWeatherByLocation(city);
            }
          });
        }, []); // Empty dependency array ensures this effect runs only once after mounting
  return (
    <>
    <UserNavbar />
    <div className="starterHome">
        <h1 className="posterHead">World Class Travel</h1>
        <button className="bookButton">Book Now</button>
    </div>
    <h1 className="typing">Explore New Destination With Us</h1>
    <div className="container1">
      <div className="carousel-container">
        <div className="loadbar" style={{ width: `${loadingProgress}%` }}></div>
        <div id="slide" ref={slideRef}>
          {data.map((item) => (
            <div
              key={item.id}
              className="item"
              style={{ backgroundImage: `url(${item.imgUrl})` }}
            >
              <div className="content">
                <div className="name">{item.name}</div>
                <div className="des">{item.desc}</div>
                
              </div>
            </div>
          ))}
        </div>
        <div className="buttons">
          <button id="prev" onClick={handleClickPrev}>
            <FontAwesomeIcon icon={faAngleLeft} />
          </button>
          <button id="next" onClick={handleClickNext}>
            <FontAwesomeIcon icon={faAngleRight} />
          </button>
        </div>
        </div>
      </div>
      
        <div className="weatherSearch">
          <h1 className="typing">Get a Glimpse of the weather in any location</h1>
          <form id="form"><input type="text" id="search" placeholder="Enter Location " autocomplete="off"/>  
          </form>  
          <main id="main">  
          </main>  
        </div>
        <br />
        <div className="cardHolder">
        <div className="cardContainer">
        <div class="card">
          <img src="https://images.pexels.com/photos/3061217/pexels-photo-3061217.jpeg?auto=compress&cs=tinysrgb&w=800" className="cardImg" alt="" />
          <section>
            <h3 className="cardHeading1">OUR MISSION</h3>
            <p className="cardPara1">We’ve always worked towards providing a platform for people where they can have the best traveling experience, where they don’t have to worry about the accommodations, the transportation, the food or even whether they’ll be able to get the most out of a place because with our well curated itineraries.</p>
          </section>
        </div>
        
        <div class="card-reverse">
          <img src="https://images.pexels.com/photos/2870346/pexels-photo-2870346.jpeg?auto=compress&cs=tinysrgb&w=800" className="cardImg" alt="" />
          <section>
            <h3 className="cardHeading">OUR VISION</h3>
            <p className="cardPara">To be the most trusted travel community in India. We want to create a space where responsible tourism and adventure can go hand in hand. To promote eco-tourism and have the local communities share the socio-economic benefits associated with traveling as well.</p>
          </section>
        </div>
        </div>
        </div>
    
        <h1 className="typing">Let's Dive Into Spark Transformations</h1>
        {/* Carousel Slider  */}
        <div className="carousel__container">
          <div className="carousel__item">
            <img src="https://images.pexels.com/photos/1271619/pexels-photo-1271619.jpeg?auto=compress&cs=tinysrgb&w=800" className="carousel__image"/>
          </div>
          <div className="carousel__item">
            <img src="https://images.pexels.com/photos/3604913/pexels-photo-3604913.jpeg?auto=compress&cs=tinysrgb&w=800&lazy=load" className="carousel__image"/>
          </div>
          <div className="carousel__item">
            <img src="https://images.pexels.com/photos/1371360/pexels-photo-1371360.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2" className="carousel__image"/>
          </div>
        </div>
       
        <UserFeedback />
        <br />
        <div class="mapouter"><div class="gmap_canvas"><iframe width="100%" height="510" id="gmap_canvas" src="https://maps.google.com/maps?q=tourist places of india&t=&z=4&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>
        </div></div>
        <UserFooter />
    
    </>
  );
};

export default UserHome