import React, { useState } from 'react';
import Animal from '../Animal';
import AnimalPopUp from '../AnimalPopUp';

const ANIMALS = [
  {
    name: 'Animal #1',
  },
  {
    name: 'Animal #2',
  },
]

const Profile = ({ name }) => {
  const [selectedAnimal, setSelectedAnimal] = useState(null);

  return (
    <div>
      {ANIMALS.map(animal => (
        <Animal animal={animal} setSelectedAnimal={setSelectedAnimal} />
      ))}
      {/* {selectedAnimal !== null (
        <AnimalPopUp animal={selectedAnimal} setSelectedAnimal={setSelectedAnimal} />
      )} */}
    </div>
  );
}

export default Profile;


