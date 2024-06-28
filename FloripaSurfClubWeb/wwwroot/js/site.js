const toggler = document.querySelector(".btn");
toggler.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("collapsed");
});


function showToastIfNeeded(elementId) {
    var showToast = '@TempData["ShowToast"]' === 'true';
    if (showToast) {
        var toastElement = new bootstrap.Toast(document.getElementById(elementId));
        toastElement.show();
    }
}

document.addEventListener('DOMContentLoaded', function () {
    showToastIfNeeded('successToast');
});


function toggleAlunoFields(selectElement) {
    var alunoFields = document.getElementById("alunoFields");
    if (selectElement.value == "1") { // Assumindo que "Aluno" tem valor "1"
        alunoFields.style.display = "block";
    } else {
        alunoFields.style.display = "none";
    }
}