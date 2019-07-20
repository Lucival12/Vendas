function buscarCliente(data) {
    if (data.Lista.length > 0) {
        $("#listaClientes").html("<div class='form-group'><div class='col-sm-4'><b>Razão Social</b></div></div>");
        $.each(data.Lista, function (index, element) {
            var itemHTML = ['<a class="form-popup-link" onclick="selecionarCliente(\'' + element.Id + '\',\'' + element.Nome + '\',\'' + element.Rua + '\',\'' + element.Cidade + '\');">',
                "<div class='col-sm-4'>",
                element.Nome,
                "</div>",
                "</a>"].join('\n');
            $("#listaClientes").append(itemHTML);
        });
    }
    else
        $("#listaClientes").html("<p class=\"msg-sem-resultado\">Nenhum Cliente encontrado</p>");
}
function validaBuscaCliente() {
    var clienteNome = document.getElementById("clienteNomeSearch").value.trim();
    if (clienteNome.length < 0) {
        bootbox.alert("Informe um filtro para realizar a busca");
        return false;
    }
    return true;
}

function selecionarCliente(id, nome, rua, cidade) {
    document.getElementById("idCliente").value = id;
    document.getElementById("clienteNome").value = nome;
    document.getElementById("clienteRua").value = rua;
    document.getElementById("clienteCidade").value = cidade;
    $('#modalSearchCliente').modal('hide');
    $('#btnInserir').removeAttr('disabled');
}

function removerCliente() {
    document.getElementById("idCliente").value = null;
    document.getElementById("clienteNome").value = null;
    document.getElementById("clienteRua").value = null;
    document.getElementById("clienteCidade").value = null;
    $('#btnInserir').attr('disabled', 'disabled');
}
