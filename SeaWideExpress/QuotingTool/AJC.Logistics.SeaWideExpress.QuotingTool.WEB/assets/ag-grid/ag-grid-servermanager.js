function AGGridManager() {
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

    this.createServerSideDatasource = function (server) {
        return {
            getRows: function (params) {
                console.log('[Datasource] - rows requested by grid: ', params.request);

                // get data for request from our fake server
                var response = server.getData(params.request);

                // simulating real server call with a 500ms delay
                //setTimeout(function () {
                if (response.success) {
                    // supply rows for requested block to grid
                    params.success({
                        rowData: response.rows,
                        rowCount: response.rowsTotalQuantity,
                    });
                } else {
                    params.fail();
                }
                //}, 500);
            },
        };
    };

    this.saveChanges = function (gridMode, model) {
        console.log(gridMode);
        console.log(model);
    };
}


