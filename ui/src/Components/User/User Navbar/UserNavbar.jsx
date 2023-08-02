import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {  faBars, faTimes } from '@fortawesome/free-solid-svg-icons';
import './UserNavbar.css';

const UserNavbar = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const handleMenuClick = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  const handleNavLinkClick = () => {
    setIsMenuOpen(false);
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
          <a href="#header" onClick={handleNavLinkClick}>
            home
          </a>
          <a href="#packages" onClick={handleNavLinkClick}>
            packages
          </a>
          <a href="#gallery" onClick={handleNavLinkClick}>
            gallery
          </a>
          <a href="#about" onClick={handleNavLinkClick}>
            about us
          </a>
          <a href="#contact" onClick={handleNavLinkClick}>
            contact
          </a>
          <a href="#login" onClick={handleNavLinkClick}>
            login
          </a>
        </nav>
      </header>
    </div>
  );
};

export default UserNavbar;
