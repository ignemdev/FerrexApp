async function initSelect2(currentValue) {
    const response = await fetch('/Admin/Category/GetAll');
    const categories = await response.json();
    const data = categories.data.map((c) => Object.create({ id: c.id, text: c.name }));

    $('#CategoryId').select2({
        width: '100%',
        data: data,
    }).select2('val', currentValue);
}

function previewImage(files) {
    if (files && files[0]) {
        let reader = new FileReader();
        reader.onload = e => document.querySelector('#imagepreview').setAttribute('src', e.target.result);
        reader.readAsDataURL(files[0]);
    }
}