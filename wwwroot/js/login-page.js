'use strict'
let users = []
fetch('C:\Users\kenda\source\repos\521Final\Models\User.cs').then((response) => {
    console.log(response)
    return response.json()
}).then((data) => {
    console.log(data)
    users = data
})

const loginForm = document.getElementById("login-form");
const loginButton = document.getElementById("login-form-submit");
const loginErrorMsg = document.getElementById("login-error-msg");

loginButton.addEventListener("click", (e) => {
    e.preventDefault();
    const emailCheck = loginForm.username.value;
    const password = loginForm.password.value;
    const isUserFound = users.find(({ email }) => email === emailCheck)

    if (isUserFound && password === isUserFound.password) {
        alert("You have successfully logged in.");
        if (isUserFound.role === 'Executive') { location.assign(`/executive-dashboard.html#${isUserFound.userID}`) }
        else { location.assign(`/employee-dashboard.html#${isUserFound.userID}`) }
    } else {
        alert("Incorrect Name or Password");
    }
})
