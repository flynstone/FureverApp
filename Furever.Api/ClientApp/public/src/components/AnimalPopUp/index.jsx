import React from 'react';
import './animalPopUp.css'

const AnimalPopUp = (props) => {
  
  console.log("this is prooooooops ---->", props )
  
  return (props.trigger) ? (
    <div className='AnimalPopUp'>
      <div className='AnimalPopUpInner'>
        <div className='PopUpHeader'>
          <h3>A little more about me</h3>
          <button className='close-btn' onClick={() => props.setTrigger(false)}>X button</button>
        </div>

        <div className='RefugeInfo'>
          <h6>{props.trigger.name} currently await his furever home at:</h6>
          <div>{props.trigger.refuge.name}</div>
          <div>{props.trigger.refuge.address}</div>
          <div>{props.trigger.refuge.postal}</div>
        </div>
        <div className='AnimalPopImage'>{props.trigger.IMG}</div>
        <div className='AnimalDesc'>
          <h4>Hello my name is {props.trigger.name}</h4>
          <div>{props.trigger.description}</div>
        </div>
        <div className='Buttons'>
          <button>Get more info about {props.trigger.name}</button>
          <button>Like Button</button>
        </div>
      </div>  
  </div>
  ) : "";
}

export default AnimalPopUp;