import React from 'react';
import './animal.css'

const Animal = ({ animal, setSelectedAnimal }) => {
  
  return (
    <div className='AnimalTile' onClick={() => setSelectedAnimal(animal)}>
      <div className='AnimalImage'>{animal.IMG}</div>
      <div className='AnimalInfo'>
        <div>{animal.name}</div>
        <div>{animal.age}</div>
        <div>{animal.breed}</div>
      </div>
    </div>
  ) 
  // populate that with name, age, breed, img form json of api call
}

export default Animal;