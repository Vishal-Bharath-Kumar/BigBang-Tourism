import React from 'react'
import './NotFound.css'
const NotFound = () => {
  return (
    
    <div className="body">
    <div class="mars"></div>
        <img src="https://assets.codepen.io/1538474/404.svg" class="logo-404" alt='logo-404' />
        <img src="https://assets.codepen.io/1538474/meteor.svg" class="meteor" alt='meteor' />
        <p class="title">Oh no!!</p>
        <p class="subtitle">
            You’re either misspelling the URL <br /> or requesting a page that's no longer here.
        </p>
        <img src="https://assets.codepen.io/1538474/astronaut.svg" class="astronaut" alt='astronaut'/>
        <img src="https://assets.codepen.io/1538474/spaceship.svg" class="spaceship" alt='spaceship' />
    </div>
    
  )
}

export default NotFound