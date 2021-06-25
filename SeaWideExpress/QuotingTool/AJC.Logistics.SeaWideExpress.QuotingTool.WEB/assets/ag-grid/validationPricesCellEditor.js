function ValidationPricesCellEditor() { }

ValidationPricesCellEditor.prototype.init = function (params) {
    let theValue = params.value ?  params.value : "(Price)";
    this.eGui = document.createElement('div');
    this.eGui.innerHTML = `
    <input onClick="this.setSelectionRange(0, this.value.length)" value=${theValue } />
  `;
    this.eInput = this.eGui.querySelector('input');
    this.eInput.addEventListener('input', this.inputChanged.bind(this));

}

ValidationPricesCellEditor.prototype.inputChanged = function (event) {
    const val = event.target.value;
    if (!this.isValid(val)) {
        this.eInput.classList.add('invalid-cell');
    } else {
        this.eInput.classList.remove('invalid-cell');
    }
}

ValidationPricesCellEditor.prototype.isValid = function (value) {
    return parseFloat(value) > 0;
}

ValidationPricesCellEditor.prototype.getValue = function () {
    return this.eInput.value;
}

ValidationPricesCellEditor.prototype.isCancelAfterEnd = function () {
    return !this.isValid(this.eInput.value);
}

ValidationPricesCellEditor.prototype.getGui = function () {
    return this.eGui;
}

ValidationPricesCellEditor.prototype.destroy = function () {
    this.eInput.removeEventListener('input', this.inputChanged);
}