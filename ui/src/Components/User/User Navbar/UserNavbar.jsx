import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {  faBars, faTimes } from '@fortawesome/free-solid-svg-icons';
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
          <Link to='/' onClick={handleNavLinkClick}>
            home
          </Link>
          <a href="#packages" onClick={handleNavLinkClick}>
            packages
          </a>
          <a href="#gallery" onClick={handleNavLinkClick}>
            gallery
          </a>
          <Link to='/TodoList' onClick={handleNavLinkClick}>
            about us
          </Link>
          <a href="#contact" onClick={handleNavLinkClick}>
            contact
          </a>
          <Link to='/Login' onClick={handleNavLinkClick}>
            login
          </Link>
        </nav>
      </header>
    </div>
  );
};

export default UserNavbar;
