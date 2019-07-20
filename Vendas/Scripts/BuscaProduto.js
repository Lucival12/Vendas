function buscarProduto(data) {
    if (data.Lista.length > 0) {
        $("#listaProdutos").html("<div class='form-group'><div class='col-sm-4'><b>Produto</b></div><div class='col-sm-4'><b>Valor Unitário</b></div></div>");
        $.each(data.Lista, function (index, element) {
            element.ValorUnitario = toDecimalBR(element.ValorUnitario);
            var itemHTML = ['<a class="form-popup-link" onclick="selecionarProduto(\'' + element.Id + '\',\'' + element.Nome + '\',\'' + element.ValorUnitario + '\');">',
                "<div class='col-sm-4'>", 
                element.Nome,
                "</div>",
                "<div class='col-sm-4'>",
                element.ValorUnitario,
                "</div>",
                "</a>"].join('\n');
            $("#listaProdutos").append(itemHTML);
        });
    }
    else
        $("#listaProdutos").html("<p class=\"msg-sem-resultado\">Nenhum Produto encontrado</p>");
}
function validaBuscaProduto() {
    var produtoNome = document.getElementById("produtoNomeSearch").value.trim();
    
    if (produtoNome.length < 0) {
        bootbox.alert("Informe um filtro para realizar a busca");
        return false;
    }
    return true;
}

function selecionarProduto(id, nome, valor) {
    
    var itemSelecionado = $("#itemSelecionado").val();
    var quantidade = $("#produtoQuantidade").val();
    document.getElementById("PedidoVendaItens_" + itemSelecionado + "__idProduto").value = id;
    document.getElementById("ProdutoNome_" + itemSelecionado).value = nome;
    document.getElementById("ProdutoQtd_" + itemSelecionado).value = quantidade != undefined && quantidade > 0 ? quantidade : 1;
    document.getElementById("ProdutoValorUnitario_" + itemSelecionado).value = valor;
    document.getElementById("ProdutoValorTotal_" + itemSelecionado).value = valor;
    calcularTotal(itemSelecionado);
    $('#modalSearchProduto').modal('hide');
}
