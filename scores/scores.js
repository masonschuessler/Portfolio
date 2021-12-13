"use strict";

let scores = [];
let scoresString = [];

let score = "";
let firstName = "";
let lastName = "";
let str = "";

const displayScores = () => {
    // let total = scores.reduce((sum, a) => sum + a, 0);
    let total = 0;
    let i = 0;
    for (; i < scores.length; i++) {
        total += scores[i];
    }
    let avg = (total / scores.length).toFixed(1);
    // $("#average_score").val(avg);
    $("#scores").val(scoresString.join("\n"));
    document.getElementById("average_score").textContent = avg;
    // document.getElementById("scores").textContent = str;
};

$(document).ready( () => {
    $("#add_button").click( () => {
        score = document.getElementById("score").value;
        firstName = document.getElementById("first_name").value.toUpperCase();
        lastName = document.getElementById("last_name").value.toUpperCase();
        str = `${lastName}, ${firstName}: ${score}`;
        scores.push(parseFloat(score));
        scoresString.push(str);
        
        // get the add form ready for next entry
        $("#first_name").val( "" );
        $("#last_name").val( "" );
        $("#score").val( "" );
        $("#first_name").focus();

        displayScores();
    }); // end click()
    
    $("#clear_button").click( () => {
        scores = [];
        scoresString = [];
        // remove the score data from the web page
        document.getElementById("average_score").textContent = "";

        $("#scores").val( "" );

        $("#first_name").focus();
    }); // end click()
       
    $("#sort_button").click( () => {
        scoresString.sort();
        $("#scores").val(scoresString.join("\n"));
    }); // end click()
    
    $("#first_name").focus();
}); // end ready()