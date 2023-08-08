import React from 'react'
import { Link } from 'react-router-dom';

const AgentNavbar = () => {

    const handleLogout = () => {
        // Expire the token and remove it from the local storage
        localStorage.removeItem('token');
      };
  return (
    <div>
        <nav className="navbar1">
        <div className="navbar-container container">
          <input type="checkbox" name="" id="" />
          <div className="hamburger-lines">
            <span className="line line1"></span>
            <span className="line line2"></span>
            <span className="line line3"></span>
          </div>
          <ul className="menu-items">
            <li>
              <Link to="/AdminGallery">Packages</Link>
            </li>
            <li>
              <Link to="/AdminGallery">Hotels</Link>
            </li>
            <li>
              {/* Call the handleLogout function on click */}
              <Link to="/Login" onClick={handleLogout}>
                Logout
              </Link>
            </li>
          </ul>
          <h1 className="logo1">Welcome Agent!</h1>
        </div>
      </nav>
    </div>
    
  )
}

export default AgentNavbar