// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let Nombre = "";
let Apellido = ""; 
let Documento = "";

let nombre_lb = "";
let isbn = "";

let id_us = "";
let id_lib = "";
let fecha_p = "";
let fecha_ent = "";

let isupdate_user = false;
let isupdate_libro = false;

let id = 0;
let id_user = 0;

OnchangeNombreLibro = () => {
    nombre_lb = document.getElementById("nombre_lb").value;
}

onChangeIsbn = () => {
    isbn = document.getElementById("isbn").value
}

onChangeNombre = () => {
    Nombre = document.getElementById("nombre").value
}

onChangeApellido = () => {
    Apellido = document.getElementById("apellido").value
}

onChangeDocumento = () => {
    Documento = document.getElementById("documento").value
}

onSendInfoUser = () => {
    if (!isupdate_user) {
        fetch("http://localhost:5000/api/usuario", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "Nombre": Nombre,
                "Apellido": Apellido,
                "Documento": Documento
            })
        })
            .then((res) => alert(res))
            .catch((err) => console.log(err))
    }
    else {
            fetch(`http://localhost:5000/api/usuario/${id}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    "Nombre": Nombre,
                    "Apellido": Apellido,
                    "Documento": Documento
                })
            })
                .then((res) => alert(res))
                .catch((err) => console.log(err))
    }
}
onSendInfoLib = () => {
    fetch(`http://localhost:5000/api/libro/${id_libro}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "Nombre": nombre_lb,
            "ISBN": isbn,
        })
    })
        .then((res) => alert(res))
        .catch((err) => console.log(err))
}


OnchangeIdUser = () => {
    id_us = document.getElementById("id_us").value;
    
}
OnchangeIdLibro = () => {
    id_lib = document.getElementById("id_lib").value;
}

OnSendPresamo = () => {
    fetch("http://localhost:5000/api/prestamo", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "Id_usuario": id_us,
            "Id_libro": id_lib
        })
    })
        .then((res) => alert(res))
        .catch((err) => console.log(err))
}

OnCahngeUserUpdate = () => {
    isupdate_user = true;
}

OnCahngeLibroUpdate = () => {
    isupdate_libro = true;
    }

    getPrestamos = async () => {
        try {
            const response = await fetch("http://localhost:5000/api/prestamos");

            if (response.ok) {
                const data = await response.json();
                console.log(data)
                data.map(e => {
                    document.querySelector(".content").innerHTML += `
                    <div class="text-secondary p-2 bg-dark" style="width: 20%">
                        <section>
                            <h5 class="text-center">${e.nombre}</h5>
                        </section>
                        <section class="mt-2">
                            <h6 class="mt-4">${e.fecha_final}</h6>
                            <h6 class="mt-4">${e.nombre_libro}</h6>
                        </section>
                    </div>
                `
                })

            }
        }
        catch (err) {
            console.error('Error en la solicitud:', err);
        }
    }

    window.addEventListener("DOMContentLoaded", getPrestamos());

document.getElementById("nombre").addEventListener("change", onChangeNombre);
document.getElementById("apellido").addEventListener("change", onChangeApellido);
document.getElementById("documento").addEventListener("change", onChangeDocumento);
document.getElementById("sendus").addEventListener("click", onSendInfoUser);

document.getElementById("nombre_lb").addEventListener("change", OnchangeNombreLibro);
document.getElementById("isbn").addEventListener("change", onChangeIsbn);
document.getElementById("sendlb").addEventListener("click", onSendInfoLib);

document.getElementById("id_us").addEventListener("change", OnchangeIdUser);
document.getElementById("id_lib").addEventListener("change", OnchangeIdLibro);
document.getElementById("sendp").addEventListener("click", OnSendPresamo);

document.getElementById("edit_user").addEventListener("click", OnchangeUserUpdate);
document.getElementById("edit_Libro").addEventListener("click", OnchangeLibroUpdate);