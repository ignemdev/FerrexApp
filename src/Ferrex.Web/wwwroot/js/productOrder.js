async function initSelect2() {
    const response = await fetch('/Admin/Product/GetAll');
    const categories = await response.json();
    const data = categories.data.map((c) => Object.create({ id: c.id, text: c.name }));

    $('#ProductId').select2({
        width: '100%',
        data: data,
    });
}