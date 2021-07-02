class TypeaheadEditor {
    static newAdvancedSource(engine) {
        return {
            ttAdapter: function (params) {
                return function (q, sync) {
                    if (q === '' && params.minLength === 0) {
                        sync(engine.all());
                    } else {
                        engine.search(q, sync);
                    }
                };
            },
            get: function (value) {
                return engine.get(value);
            }
        };
    }

    static newSource(list, valueField = "value", displayField = "label", params) {
        const engine = new Bloodhound({
            datumTokenizer: Bloodhound.tokenizers.obj.whitespace(displayField),
            queryTokenizer: Bloodhound.tokenizers.whitespace,
            identify: (obj) => (obj[valueField]),
            local: list
        });

        return this.newAdvancedSource(engine);
    }

    static newStore(name, list, params, valueField = "value", displayField = "label") {
        return {
            name,
            ...params,
            display: displayField,
            source: this.newSource(list, valueField, displayField, params)
        };
    }

    static getFormatter(store) {
        return function (params) {
            var { value } = params;

            if (!value) return "";

            if (typeof value !== 'object') value = store.source.get([value])[0];

            if (!value) return "";

            return value[store.display || "label"];
        }
    }

    constructor() {
    }

    handleTab = (event) => {
        const value = $(this.input).typeahead('val');
        if (value === "") this.setValue(null);
        /* Emulate tab - not for now
        event.stopPropagation();
        event.preventDefault();
        var evt = new KeyboardEvent("keydown", { 'keyCode': 9, 'which': 9, 'key': 'Tab', 'shiftKey': event.shiftKey });
        this.params.onKeyDown(evt);
        */
    }

    handleKeyDown = (event) => {
        if (!event) event = window.event;

        // Arrow Down
        if (event.keyCode === 40) $(this.input).typeahead('open');
        // TAB or ENTER
        else if (event.keyCode === 13 || event.keyCode === 9) this.handleTab(event);
    }

    handleChange = (event, datum) => {
        this.setValue(datum);
    }

    setValue(newValue) {
        const { store } = this.params;

        if (typeof newValue !== 'object') {
            newValue = store.source.get([newValue])[0];
        }

        this.value = newValue;

        $(this.input).typeahead('val', newValue ? newValue[store.display || "label"] : "");
     }

    init(params) {
        this.params = params;

        this.container = document.createElement('div');
        this.container.className = "tt-container";
        this.container.style.minWidth = (params.column.actualWidth-2) + 'px'

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

        allStores = allStores.map((store) => ({ ...store, source: store.source.ttAdapter(config) }));

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