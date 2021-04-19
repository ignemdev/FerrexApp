let idHidden = document.querySelector('#Id');

async function initSelect2(currentValue) {
    const response = await fetch('/Admin/Category/GetAll');
    const categories = await response.json();
    const data = categories.data.map((c) => Object.create({ id: c.id, text: c.name }));

    $('#CategoryId').select2({
        width: '100%',
        data: data,
    }).select2('val', currentValue);
}

function openStockDialog(id) {
    Metro.dialog.open('#stockdialog');
    idHidden.value = id;
}

function emptyDialogInputs() {
    idHidden.value = 0;
}