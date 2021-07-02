function ValidationPricesCellEditor() { }

ValidationPricesCellEditor.prototype.init = function (params) {
    this.params = params;
    this.eGui = document.createElement('div');
    //this.eGui.setAttribute("onclick", "alert('seba');");


}

ValidationPricesCellEditor.prototype.inputChanged = function (event) {
    const val = event.target.value;
    if (!this.isValid(val)) {
        this.eInput.classList.add('invalid-cell');
    } else {
        this.eInput.classList.remove('invalid-cell');
    }
}


ValidationPricesCellEditor.prototype.afterGuiAttached= function(){
    this.eGui.innerHTML = `
    <input onClick="this.setSelectionRange(0, this.value.length)" value=${this.params.value} />
  `;
    this.eInput = this.eGui.querySelector('input');

    if (this.params.charPress) {
        this.eInput.value = this.params.charPress;
    } else {
        this.eInput.value = this.params.value;
    }

    this.eInput.addEventListener('input', this.inputChanged.bind(this));
    this.eInput.focus();
}

ValidationPricesCellEditor.prototype.isValid = function (value) {
    let isCurrency = /^(?=.*[1-9])\d{0,5}(\.\d{1,2})?$/.test(value)
    return isCurrency || (value == "") ;
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