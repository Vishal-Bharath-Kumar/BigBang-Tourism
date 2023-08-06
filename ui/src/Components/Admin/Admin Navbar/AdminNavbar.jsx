import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './AdminNavbar.css';


const AdminNavbar = () => {
 

  return (
    <div>
       <nav class="navbar1">
        <div class="navbar-container container">
            <input type="checkbox" name="" id=""/>
            <div class="hamburger-lines">
                <span class="line line1"></span>
                <span class="line line2"></span>
                <span class="line line3"></span>
            </div>
            <ul class="menu-items">
                <li><Link to= '/AdminDashboard'>Dashboard</Link></li>
                <li><Link to= '/AdminGallery'>Gallery</Link></li>
                <li><Link to='/Login'>Logout</Link></li>
            </ul>
            <h1 class="logo1">Welcome Admin!</h1>
        </div>
    </nav>
    </div>
  );
};

export default AdminNavbar;
