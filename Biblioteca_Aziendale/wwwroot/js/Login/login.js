function controlla_login() {
    if (document.getElementById('user').value.length < 2) {
        alert("Username " + document.getElementById('user').value + "troppo breve");
        return false;
    }

    if (document.getElementById('psw').value.length < 2) {
        alert("Password troppo breve");
        return false;
    }
}



// controlli nome, cognome, username
function controlli_Registrazione() {
    if (document.getElementById('username').value.length < 2) {
        alert("Username troppo breve");
        return false;
    }

    if (document.getElementById('nome').value.length < 2) {
        alert("Nome troppo breve");
        return false;
    }

    if (document.getElementById('cognome').value.length < 2) {
        alert("Cognome troppo breve");
        return false;
    }


    if (document.getElementById('psw').value != document.getElementById('psw2').value) {
        alert("Le password non councidono");
        return false;
    }

    let errors = [];

    if (document.getElementById('psw').value.length < 8)
        errors.push("La password deve avere almeno 8 caratteri");

    if (document.getElementById('psw').search(/[a-z]/) < 0)
        errors.push("La password deve contenere almeno 1 lettera minuscola");

    if (document.getElementById('psw').search(/[A-Z]/) < 0)
        errors.push("La password deve contenere almeno 1 lettera minuscola");

    if (document.getElementById('psw').search(/[0-9]/) < 0)
        errors.push("La password deve contenere almeno 1 numero");

    if (errors.length > 0) {
        alert(errors.join("\n"));
        return false;
    }

    return true;
}
