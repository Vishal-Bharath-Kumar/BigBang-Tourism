import React, { useRef,  useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faAngleLeft, faAngleRight } from "@fortawesome/free-solid-svg-icons";
import UserNavbar from '../User Navbar/UserNavbar'
import './UserHome.css'

const UserHome = () => {

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
  return (
    <>
    <UserNavbar />
    <div>

    </div>
    <div className="container">
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
    
    </>
  )
}

export default UserHome