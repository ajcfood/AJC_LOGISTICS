// specify the columns
var columnDefs = [
    { headerName: "id", field: "id" },
    { headerName: "fechadesde", field: "fechadesde" },
    { headerName: "fechahasta", field: "fechahasta" },
    { headerName: "zona", field: "zona" },
    { headerName: "zonaDescripcion", field: "zonaDescripcion" },
    { headerName: "precio", field: "precio" }
];

// let the grid know which columns to use
var gridOptions = {
    columnDefs: columnDefs,
    defaultColDef: {
        sortable: true,
        filter: true
    },
    defaultColDef: {
        flex: 1,
        minWidth: 100,
    },
    // use the server-side row model instead of the default 'client-side'
    rowModelType: 'serverSide',
};