import React from "react";
import axios from "axios";
//import { Link } from 'react-router-dom'
import Location from './components/Location'
import WeatherInfo from './components/WeatherInfo'
import "./App.css";

class App extends React.Component {
  state = {forecastDetails: null}

  onSearchSubmit = async (inputValue) => {
    const response = await axios.get(`https://api.openweathermap.org/data/2.5/weather?q=${inputValue}&units=imperial&appid=fd0ca1fbb9a7987ada4614a1422654ed`)
    this.setState({forecastDetails: response.data})
  }

  render() {
    return(
      <div className="result">
        <h1>Weather Information:</h1>
        <Location onSearchSubmit = {this.onSearchSubmit} />
        {this.state.forecastDetails ? <WeatherInfo forecastDetails = {this.state.forecastDetails} /> : <div></div>}
      </div>
    )
  }
}

export default App
