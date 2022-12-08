window.onload = function(){
    ListaPersonas();
}

function ListaPersonas() {
    pintar({
        url: "Persona/ListaPersonas",
        propiedades: ["nombreCompleto", "correo"],
        cabeceras: ["Nombre Completo", "Correo"]
    }, {
        url: "Persona/ListaPersonas",
        formulario: [
            [
                {
                    class: "col-md-6",
                    label: "Nombre Completo",
                    name: "nombreCompleto",
                    type:"text"
                }
            ]
        ]
    })
}
