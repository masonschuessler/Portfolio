import React from 'react'

class Location extends React.Component {
    constructor(props) {
        super(props)
        this.state = {inputValue: ''}
    }

    onFormSubmit = (e) => {
        e.preventDefault()
        this.props.onSearchSubmit(this.state.inputValue)
    }

    render() {
        return(
            <form className='text-center' onSubmit={this.onFormSubmit}>
                <input className='text-center' type='text' name='city' placeholder = 'City to search' onChange={(e) => this.setState({inputValue: e.target.value})} />
            </form>
        )
    }
}

export default Location