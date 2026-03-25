function toggleChat() {
    $("#chat-container").toggle();
}

function enviarMensagem() {
    let msg = $("#chat-input").val();

    if (!msg) return;

    adicionarMensagem("Você", msg);

    $.ajax({
        url: "/chat",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(msg),
        success: function (res) {
            adicionarMensagem("Bot", res);
        }
    });

    $("#chat-input").val("");
}

function adicionarMensagem(remetente, texto) {
    $("#chat-messages").append(
        `<div><strong>${remetente}:</strong> ${texto}</div>`
    );

    $("#chat-messages").scrollTop($("#chat-messages")[0].scrollHeight);
}