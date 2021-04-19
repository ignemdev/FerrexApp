let idHidden = document.querySelector('#Id');
let nameInput = document.querySelector('#Name');
let descriptionInput = document.querySelector('#Description');

function openEditDialog(id, name, description) {
    Metro.dialog.open('#adddialog');
    idHidden.value = id;
    nameInput.value = name;
    descriptionInput.value = description;
}

function emptyDialogInputs() {
    idHidden.value = 0;
    nameInput.value = '';
    descriptionInput.value = '';
}