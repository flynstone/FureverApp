import React from 'react';
import './Header.css';

const Header = () => {
  return (
    <div className='Header'>
      <button>Profile</button>
      <h2>Furever Home</h2>
      <button>Extra parameters</button>
    </div>
  )
}

// everything related to Header goes here :  onClick js, html, icons etc
// add logic to display icons at top when user is logged in, hide if not

export default Header;

