$(document).ready(function () {
    carregar();
});

function carregar() {
    $.get("/usuario/listar", function (data) {

        let html = "";

        data.forEach(u => {
            html += `
                <tr>
                    <td>${u.nome}</td>
                    <td>${u.valorHora}</td>
                    <td>${formatarData(u.dataCadastro)}</td>
                    <td>${u.ativo ? "Sim" : "Não"}</td>
                    <td>
                        <button class="btn btn-warning btn-sm" onclick='editar(${JSON.stringify(u)})'>Editar</button>
                        <button class="btn btn-danger btn-sm" onclick="excluir(${u.id})">Excluir</button>
                    </td>
                </tr>`;
        });

        $("#tabela").html(html);
    });
}

function abrirModal() {
    $("#id").val("");
    $("#nome").val("");
    $("#valorHora").val("");
    $("#ativo").prop("checked", true);

    $("#modalUsuario").modal("show");
}

function editar(u) {
    $("#id").val(u.id);
    $("#nome").val(u.nome);
    $("#valorHora").val(u.valorHora);
    $("#ativo").prop("checked", u.ativo);

    $("#modalUsuario").modal("show");
}

function salvar() {
    let usuario = {
        id: $("#id").val() ? parseInt($("#id").val()) : 0,
        nome: $("#nome").val(),
        valorHora: parseFloat($("#valorHora").val()) || 0,
        ativo: $("#ativo").is(":checked")
    };

    let url = usuario.id ? "/usuario/editar" : "/usuario/criar";

    $.ajax({
        url: url,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(usuario),
        success: function () {
            $("#modalUsuario").modal("hide");
            carregar();
        },
        error: function (err) {
            console.log(err); // 👈 importante pra debug
            alert("Erro ao salvar");
        }
    });
}

function excluir(id) {
    if (!confirm("Deseja excluir?")) return;

    $.ajax({
        url: `/usuario/excluir/${id}`,
        type: "DELETE",
        success: carregar,
        error: () => alert("Erro ao excluir")
    });
}

function formatarData(data) {
    if (!data) return "";

    let d = new Date(data);

    if (isNaN(d)) return "";

    return d.toLocaleDateString("pt-BR") + " " + d.toLocaleTimeString("pt-BR");
}