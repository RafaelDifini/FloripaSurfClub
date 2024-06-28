document.addEventListener('DOMContentLoaded', function () {
    const toggler = document.querySelector(".btn");
    if (toggler) {
        toggler.addEventListener("click", function () {
            document.querySelector("#sidebar").classList.toggle("collapsed");
        });
    }

    if (typeof showToast !== 'undefined' && showToast) {
        showToastIfNeeded('successToast');
    }

    const tipoUsuarioSelect = document.querySelector("select[name='TipoUsuario']");
    if (tipoUsuarioSelect) {
        tipoUsuarioSelect.addEventListener("change", function () {
            toggleAlunoFields(this);
        });

        toggleAlunoFields(tipoUsuarioSelect);
    }
});

function showToastIfNeeded(elementId) {
    var toastElement = new bootstrap.Toast(document.getElementById(elementId));
    toastElement.show();
}

function toggleAlunoFields(selectElement) {
    var alunoFields = document.getElementById("alunoFields");
    if (selectElement.value == "1") { // Assumindo que "Aluno" tem valor "1"
        alunoFields.style.display = "block";
    } else {
        alunoFields.style.display = "none";
    }
}
