import React, {useState} from 'react'

import './App.css';

function App() {
  const [calc, setCalc] = useState("")
  const [answer, setAnswer] = useState("")

  const ops = ["+", "-", "*", "/", "."]

  const updateCalc = (value) => {
    // check for "error" conditions
    if ((ops.includes(value) && (calc === "")) || (ops.includes(value) && (ops.includes(calc.slice(-1)))))
    {
      return
    }

    setCalc(calc + value)

    if (!ops.includes(value))
    {
      setAnswer(eval(calc + value).toString())
    }
  }

  const calculate = () => {
    setCalc(eval(calc).toString())
  }

  const deleteChar = () => {
    if (calc === "")
    {
      return
    }

    const value = calc.slice(0, -1)
    setCalc(value)
  }

  return (
    <div className="app">
      <div className='wrapper'>
        <div className='display'>
          <div className='result'>
          {answer ? <span>({answer})</span> : ''} &nbsp;&nbsp;
          {calc || '0'}
          </div>
          <div className='operators'>
            <button onClick={() => updateCalc('+')}>+</button>
            <button onClick={() => updateCalc('-')}>-</button>
            <button onClick={() => updateCalc('*')}>*</button>
            <button onClick={() => updateCalc('/')}>/</button>
            <button onClick={deleteChar}>DEL</button>
          </div>
          <div className='digits'>
          <button onClick={() => updateCalc('1')}>1</button>
          <button onClick={() => updateCalc('2')}>2</button>
          <button onClick={() => updateCalc('3')}>3</button>
          <button onClick={() => updateCalc('4')}>4</button>
          <button onClick={() => updateCalc('5')}>5</button>
          <button onClick={() => updateCalc('6')}>6</button>
          <button onClick={() => updateCalc('7')}>7</button>
          <button onClick={() => updateCalc('8')}>8</button>
          <button onClick={() => updateCalc('9')}>9</button>
          <button onClick={() => updateCalc('0')}>0</button>
          <button onClick={() => updateCalc('.')}>.</button>
          <button onClick={calculate}>=</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
