document.getElementById("formTarea").addEventListener("submit", function (event) {
    event.preventDefault(); // Evita que la página se recargue

    // 1. Capturar los valores ingresados por el usuario
    const titulo = document.getElementById("titulo").value;
    const descripcion = document.getElementById("descripcion").value;
    const fechaLimite = document.getElementById("fechaLimite").value;
    const prioridad = document.getElementById("prioridad").value;

    // 2. Llamar a la función que crea la tarjeta
    agregarTarea(titulo, descripcion, fechaLimite, prioridad);

    // 3. Cerrar el modal y limpiar el formulario
    document.getElementById("formTarea").reset();
    let modal = new bootstrap.Modal(document.getElementById('modalTarea'));
    modal.hide();
});

function getColorPrioridad(prioridad) {
    switch (prioridad) {
        case "Alta": return "danger"; // Rojo
        case "Media": return "warning"; // Amarillo
        case "Baja": return "success"; // Verde
        default: return "secondary"; // Gris
    }
}


function agregarTarea(titulo, descripcion, fechaLimite, prioridad) {
    const listaTareas = document.getElementById("listaTareas");

    // Crear el elemento de la tarjeta
    const card = document.createElement("div");
    card.classList.add("col-md-4"); // Hace que las tarjetas sean responsivas

    // Definir el contenido de la tarjeta con Bootstrap
    card.innerHTML = `
        <div class="card border-${getColorPrioridad(prioridad)} shadow-sm">
            <div class="card-body">
                <h5 class="card-title">${titulo}</h5>
                <p class="card-text">${descripcion}</p>
                <p class="text-muted">Fecha Límite: <strong>${fechaLimite}</strong></p>
                <span class="badge bg-${getColorPrioridad(prioridad)}">${prioridad}</span>
                <button class="btn btn-danger btn-sm mt-2 eliminar-tarea">Eliminar</button>
            </div>
        </div>
    `;

    // Agregar la tarjeta al contenedor de tareas
    listaTareas.appendChild(card);

    // Agregar evento al botón de eliminar
    card.querySelector(".eliminar-tarea").addEventListener("click", function () {
        card.remove(); // Elimina la tarea
    });
}

