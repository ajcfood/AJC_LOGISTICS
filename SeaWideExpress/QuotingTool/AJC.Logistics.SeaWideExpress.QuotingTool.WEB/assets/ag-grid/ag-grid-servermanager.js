function AGGridManager() {
    this.instances = {};

    this.onGridReady = function (listener, id) {
        const grid = this.instances[id] || {id};
        if (grid.ready) listener(grid);
        else {
            if (grid.api) grid.api.addEventListener('gridReady', listener);
        }            
    }


    this.initGrid = function (id, options) {
        var container = document.querySelector('#' + id);

        const grid = this.instances[id] || {id};

        const _gridReady = options.onGridReady;
        options.onGridReady = function handleGridReady(event) {
            grid.ready = true;
            if (_gridReady) _gridReady(event);
        }

        agGrid.Grid(container, options);

        grid.api     = options.api;
        grid.options = options;

        if (options.endpoint) {

            // setup the server with a first call.
            grid.server = this.createServer(options.endpoint);

            // create datasource with a reference to the server.
            grid.datasource = this.createServerSideDatasource(grid.server);

            // Initializes the where conditions
            if (options.where) grid.datasource.setWhere(options.where);

            // set serverside datasource.
            grid.api.setServerSideDatasource(grid.datasource);
        }

        this.instances[id] = grid;

        return grid;
    }

    this.getGrid = function (id) {
        return this.instances[id];
    }

    this.createServer = function (entityTypeEndPoint) {
        return {
            getData: function (request) {
                // take a copy of the data to return to the client
                var requestedRows = null;
                var totalQuantityRows = 0;
                $.ajax({
                    url: entityTypeEndPoint,
                    dataType: "json",
                    type: "POST",
                    async: false,
                    cache: false,
                    data: JSON.stringify(request),
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        requestedRows = data.rows;
                        totalQuantityRows = data.rowsTotalQuantity;
                    },
                    error: function (xhr) {
                        alert(JSON.stringify(xhr));
                    }
                });
                return {
                    success: true,
                    rows: requestedRows,
                    rowsTotalQuantity : totalQuantityRows,
                };
            },
        };
    };

    this.fetchLOV = function(endpointName) {
        let requestedRows = [];
        $.ajax({
            url: endpointName,
            dataType: "json",
            type: "GET",
            async: false,
            cache: false,
            success: function (rows) {
                requestedRows = rows;
            },
            error: function (xhr) {
                alert(JSON.stringify(xhr));
            }
        });
        return requestedRows;
    }

    this.createServerSideDatasource = function (server) {
        const me = {};
        Object.assign(me, {
            where: null,
            setWhere: function (where) {
                if (!where) me.where = null;
                else me.where = Object.keys(where).map((Field) => ({Field, Value: where[Field]}));
            },
            getRows: function (params) {
                console.log('[Datasource] - rows requested by grid: ', params.request);

                const request = Object.assign({}, params.request);
                if (me.where) request.whereClause = me.where;

                // get data for request
                var response = server.getData(request);

                if (response.success) {
                    // supply rows for requested block to grid
                    params.success({
                        rowData: response.rows,
                        rowCount: response.rowsTotalQuantity,
                    });
                } else {
                    params.fail();
                }
            },
        });

        return me;
    };

    this.updateEntity = function (entity, endpoint, callback) {
        $.ajax({
            url: endpoint,
            dataType: "json",
            type: "POST",
            async: false,
            cache: false,
            data: JSON.stringify(entity),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var idEntity = {
                    idEntityAffected: data?.idEntity, idEntityRequest: data?.idEntityRequest};
                if (idEntity && callback)
                    callback(idEntity);
            },
            error: function (xhr) {
                console.log("Error - Data Sended: " + JSON.stringify(xhr.responseJSON.DataReceived));
                alert(xhr.responseJSON.error);
            }
        });
    }
}

let agGridManager;
if (!agGridManager) agGridManager = new AGGridManager();