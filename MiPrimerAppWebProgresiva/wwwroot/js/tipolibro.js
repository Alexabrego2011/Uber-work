window.onload = function () {
    listaTipoLibro();
}

function listaTipoLibro() {
    pintar({
        url: "TipoLibro/listaTipolibro",
        propiedades: ["nombre", "descripcion"],
        cabeceras: ["Tipo Libro", "Descripcion"],
        titlePopup: "Tipo Libro"
    }, {
    url: "TipoLibro/listaTipolibro",
        formulario: [
            [
                {
                    class: "col-md-6",
                    label: "Nombre Tipo Libro",
                    name: "nombretipolibrobuscar",
                    type: "text"
                }
            ]
        ]
}, {
    type: "popup",
        urlguardar: "TipoLibro/guardarTipolibro",
            formulario: [
                [
                    {
                        class: "col-md-6",
                        label: "Nombre Tipo Libro",
                        name: "nombretipolibrobuscar",
                        type: "text"
                    }, {
                        class: "col-md-6",
                        label: "Descripcion Tipo Libro",
                        name: "descripcion",
                        type: "textarea"
                    }
                ]
            ]
}
    )
}