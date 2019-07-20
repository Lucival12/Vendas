function excluirItem(i) {
    document.getElementById("divItem_" + i).remove();
    $("#itemSelecionado").val(null);
    calcularTotalCompra();
}
function abrirModalProduto(i) {
    $("#itemSelecionado").val(i);
    $('#modalSearchProduto').modal('show');
}

function inserirItem() {
    var qtd = $("#qtdItens").val();
            var divHtml = '' +
                '<div class="form-group" id="divItem_' + qtd + '">' +
                    '<input id="PedidoVendaItens_' + qtd + '__idProduto" name="PedidoVendaItens[' + qtd + '].idProduto" type="hidden" value="value" />' +
                    '<div class="col-sm-3">' +
                        '<input class="form-control readonly" id="ProdutoNome_' + qtd+'" readonly="true" type="text" value="">'+
                    '</div>' +
                   '<div class="col-sm-1 form-browse">'+
                        '<button type="button" class="btn btn-info btn-icon"  onclick="abrirModalProduto(\'' + qtd + '\');" >'+
                                '<span class="glyphicon glyphicon-search"></span>'+
                        '</button>'+
                '</div>' +
                '<div class="col-sm-2">' +
                '<input class="form-control" id="ProdutoValorUnitario_' + qtd + '" name="PedidoVendaItens[' + qtd + '].vValorUnitario" type="text" value="" onchange="calcularTotal(' + qtd + ')">' +
                '</div>' +
                '<div class="col-sm-1">' +
                '<input class="form-control" id="ProdutoQtd_' + qtd + '"  type="text" value="" name="PedidoVendaItens[' + qtd + '].vQuantidade"  onchange="calcularTotal(' + qtd + ')">' +
                '</div>' +
                '<div class="col-sm-3">' +
                '<input class="form-control readonly" id="ProdutoValorTotal_' + qtd + '"  name="PedidoVendaItens[' + qtd + '].vValorTotalProduto" readonly="true" type="text" value="">' +
                '</div>' +
                    '<div class="col-sm-1 form-remover">' +
                        '<button type="button" class="btn btn-danger btn-icon" onclick="excluirItem(\'' + qtd + '\');" title="Remover Item">' +
                            '<span class="glyphicon glyphicon-trash"></span>' +
                        '</button>' +
                    '</div>' +
                '</div>';

            $("#divItens_n").append(divHtml);
    $("#qtdItens").val(+qtd + +1);
    inserirMascaraDinheiroReal(["ProdutoValorUnitario_" + qtd ]);

}

