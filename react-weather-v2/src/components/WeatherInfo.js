import React from 'react'

class WeatherInfo extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return(
            <div className='infoMain'>
                <div>
                </div>
                <div>
                    <div>
                        <div>
                            <span className='temp'>{(this.props.forecastDetails.main.temp)}&deg;F</span>
                        </div>
                        <div>
                            <span className='high'>High: {(this.props.forecastDetails.main.temp_max)}&deg;F</span>
                        </div>
                        <div>
                            <span className='low'>Low: {(this.props.forecastDetails.main.temp_min)}&deg;F</span>
                        </div>
                        <div>
                            <p>Details: {this.props.forecastDetails.weather[0].description}</p>
                        </div>
                        <div>
                            <img src={`http://openweathermap.org/img/w/${this.props.forecastDetails.weather[0].icon}.png`}/>
                        </div>
                    </div>
                    <div>
                        <p>Humidity: {this.props.forecastDetails.main.humidity}&#37;</p>
                    </div>
                    <div>
                        <p>Wind Speed: {this.props.forecastDetails.wind.speed}MPH</p>
                    </div>
                </div>
                <div className='location'>
                        <p>Location: {this.props.forecastDetails.name}</p>
                </div>
            </div>
        )
    }
}

export default WeatherInfo