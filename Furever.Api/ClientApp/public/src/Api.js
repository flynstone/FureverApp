import axios from 'axios';
import React from 'react';
import { useState, useEffect } from React;

export default function setInfoData () {

  const [animalInfo, setAnimalInfo] = useState({
    animal: {},
    refuge: {}
  });

  const [profile, setProfile] = useState({
    profile: {}
  })

  useEffect(() => {
    const apiAnimals = "/api/animals"
    const apiRefuges = "/api/refuges"
    const apiProfile = "/api/profile"
  
    Promise.all([
      axios.get(apiAnimals),
      axios.get(apiRefuges),
      axios.get(apiProfile)
    ]).then((all) => {
      console.log("this is from me the api calls!!! ----->", all)
      setState(prev => ({}))
    })
  }, []);
  
}
