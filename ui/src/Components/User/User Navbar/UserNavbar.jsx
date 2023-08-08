import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faTimes } from '@fortawesome/free-solid-svg-icons';
import './UserNavbar.css';
import { Link } from 'react-router-dom';

const UserNavbar = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const handleMenuClick = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const handleNavLinkClick = () => {
    setIsMenuOpen(false);
  };

  // Function to check if the traveler is logged in
  const isTravelerLoggedIn = () => {
    const token = localStorage.getItem('token');
    return !!token; // Return true if token is present, otherwise false
  };

  // Function to handle traveler logout
  const handleLogout = () => {
    // Expire the token and remove it from the local storage
    localStorage.removeItem('token');
  };

  return (
    <div>
      <header className="header" id="header">
        <a href="#header" className="logo">
          Spark Tourism
        </a>

        <div
          id="menu-btn"
          className={`menu-btn ${isMenuOpen ? 'close' : ''}`}
          onClick={handleMenuClick}
        >
          <FontAwesomeIcon icon={isMenuOpen ? faTimes : faBars} />
        </div>

        <nav className={`navbar ${isMenuOpen ? 'active' : ''}`}>
          <Link to="/" onClick={handleNavLinkClick}>
            home
          </Link>
          <Link to="/Packages" onClick={handleNavLinkClick}>
            packages
          </Link>
          <a href="#gallery" onClick={handleNavLinkClick}>
            gallery
          </a>
          <Link to="/TodoList" onClick={handleNavLinkClick}>
            about us
          </Link>
          <Link to='/Main' onClick={handleNavLinkClick}>
            contact
          </Link>
          {/* Conditional rendering for login/logout link */}
          {isTravelerLoggedIn() ? (
            <Link to="/Login" onClick={() => { handleNavLinkClick(); handleLogout(); }}>
              logout
            </Link>
          ) : (
            <Link to="/Login" onClick={handleNavLinkClick}>
              login
            </Link>
          )}
        </nav>
      </header>
    </div>
  );
};

export default UserNavbar;
