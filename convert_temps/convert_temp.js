"use strict";

const $ = selector => document.querySelector(selector);

/*********************
*  helper functions  *
**********************/
const calculateCelsius = (temp) => (temp-32) * 5/9;
const calculateFahrenheit = (temp) => temp * 9/5 + 32;

const toggleDisplay = (label1Text, label2Text) => {
	if ($("#to_fahrenheit").checked) {
		$("#degree_label_1").textContent = ("Enter C degrees:");
		$("#degree_label_2").textContent = ("Degrees Fahrenheit:");
	}
	else if ($("#to_celsius").checked) {
		$("#degree_label_1").textContent = ("Enter F degrees:");
		$("#degree_label_2").textContent = ("Degrees Celsius:");
	}
	$("#degrees_computed").value = "";
};

/****************************
*  event handler functions  *
*****************************/
const convertTemp = () => {  
	let converted = 0;
	const temp = ($("#degrees_entered").value);
	
	if ($("#to_fahrenheit").checked) {
		converted = calculateFahrenheit(temp).toFixed(0);
	}
	else if ($("#to_celsius").checked) {
		converted = calculateCelsius(temp).toFixed(0);
	}
	$("#degrees_computed").value = (converted);

	if (isNaN(temp)) {
		$("#message").textContent = "You must enter a valid number for degrees.";
	}
	else {
		$("#message").textContent = "";
	}
};

const toCelsius = () => toggleDisplay("Enter F degrees:", "Degrees Celsius:");
const toFahrenheit = () => toggleDisplay("Enter C degrees:", "Degrees Fahrenheit:");

document.addEventListener("DOMContentLoaded", () => {
	// add event handlers
	$("#convert").addEventListener("click", convertTemp);
    $("#to_celsius").addEventListener("click", toCelsius);
    $("#to_fahrenheit").addEventListener("click", toFahrenheit);
	
	// move focus
	$("#degrees_entered").focus();
});
let timer = null;

const goToTerms = () => window.location.href = "terms/html";