class TypeaheadEditor {
    constructor() {
    }

    handleKeyDown = (event) => {
        if (!event) event = window.event;
        if (event.keyCode === 40)
            $(this.input).typeahead('open');
    }

    handleChange = (event, datum) => {
        this.setValue(datum);

    }

    setValue(newValue) {
        const { store } = this.params;

        if (typeof newValue !== 'object')
            newValue = store.source.get([newValue])[0];

        this.value = newValue;
        $(this.input).typeahead('val', newValue[store.display || "label"]);
     }

    init(params) {
        this.params = params;

        this.container = document.createElement('div');
        this.container.className = "tt-container";
        this.container.style.minWidth = params.column.actualWidth + 'px'

        this.input = document.createElement('input');
        this.input.type = "text";
        this.input.placeholder = params.placeholder;

        this.container.appendChild(this.input);
    }

    // gets called once when grid ready to insert the element
    getGui() {
        return this.container;
    }

    afterGuiAttached() {
        const { store, stores, ...config } = this.params;

        var allStores = [];
        if (stores) allStores = allStores.concat(stores);
        if (store) allStores.push(store);

        allStores = allStores.map((store) => ({ ...store, source: store.source.ttAdapter() }));

        $(this.input).typeahead(config, ...allStores)
            .on('typeahead:select', this.handleChange);
        if (this.params.charPress) {
            $(this.input).typeahead('val', this.params.charPress);
            $(this.input).typeahead('open');
        } else {
            this.setValue(this.params.value);
        }

        this.input.addEventListener('keydown', this.handleKeyDown);
        this.input.focus();
    }

    getValue() {
        return this.value;
    }

    // any cleanup we need to be done here
    destroy() { }

    isPopup() {
        return true;
    }
}

class TypeaheadRenderer {

}