// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// get the element
function conta() {
    const element = document.getElementById('aggiorna')
    var counter = 0;
    // always checking if the element is clicked, if so, do alert('hello')
    element.addEventListener('click', () => {
        counter = 1;
    });
    console.log(counter);
};
