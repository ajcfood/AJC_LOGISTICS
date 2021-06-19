function AGGridManager() {
    this.instances = {};

    this.initGrid = function (id, options) {
        var container = document.querySelector('#' + id);

        agGrid.Grid(container, options);

        const grid = { api: options.api, options };

        if (options.endpoint) {

            // setup the server with a first call.
            grid.server = this.createServer(options.endpoint);

            // create datasource with a reference to the server.
            grid.datasource = this.createServerSideDatasource(grid.server);

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
        return {
            getRows: function (params) {
                console.log('[Datasource] - rows requested by grid: ', params.request);

                // get data for request
                var response = server.getData(params.request);

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
        };
    };

    this.updateEntity = function (entity, endpoint) {
        $.ajax({
            url: endpoint,
            dataType: "json",
            type: "POST",
            async: false,
            cache: false,
            data: JSON.stringify(entity),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                alert(data.message);
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