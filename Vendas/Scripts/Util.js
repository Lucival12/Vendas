function load() {
    posLoad();
}

function adicionar(entity) {
    window.location.href = "/" + entity + "/Create";
}

function alterar(id, entity) {
    window.location.href = "/" + entity + "/Edit/"+ id;
}

function remover(id, entity) {
    window.location.href = "/" + entity + "/Delete/" + id;
}

function toDecimalBR(value) {
    return value.toLocaleString('pt-BR', { style: 'decimal', minimumFractionDigits: 2 })
}
function maskIt(w, e, m, r, a) {
    // Cancela se o evento for Backspace
    if (!e) var e = window.event
    if (e.keyCode) code = e.keyCode;
    else if (e.which) code = e.which;
    // Variáveis da função
    var txt = (!r) ? w.value.replace(/[^\d]+/gi, '') : w.value.replace(/[^\d]+/gi, '').reverse();
    var mask = (!r) ? m : m.reverse();
    var pre = (a) ? a.pre : "";
    var pos = (a) ? a.pos : "";
    var ret = "";
    if (code == 9 || code == 8 || txt.length == mask.replace(/[^#]+/g, '').length) return false;
    // Loop na máscara para aplicar os caracteres
    for (var x = 0, y = 0, z = mask.length; x < z && y < txt.length;) {
        if (mask.charAt(x) != '#') {
            ret += mask.charAt(x); x++;
        }
        else {
            ret += txt.charAt(y); y++; x++;
        }
    }
    // Retorno da função
    ret = (!r) ? ret : ret.reverse()
    w.value = pre + ret + pos;
}
// Novo método para o objeto 'String'
String.prototype.reverse = function () {
    return this.split('').reverse().join('');
};


function number_format(number, decimals, dec_point, thousands_sep) {
    var n = number, c = isNaN(decimals = Math.abs(decimals)) ? 2 : decimals;
    var d = dec_point == undefined ? "," : dec_point;
    //var t = thousands_sep == undefined ? "." : thousands_sep,
        s = n < 0 ? "-" : "";
    var i = parseInt(n = Math.abs(+n || 0).toFixed(c)) + "", j = (j = i.length) > 3 ? j % 3 : 0;
    return s + (j ? i.substr(0, j) : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1") + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
}

function inserirMascaraDinheiroReal(arrayCamposDinheiro) {
    for (var i = 0; i < arrayCamposDinheiro.length; i++) {
        var input = "#" + arrayCamposDinheiro[i];
        $(input).priceFormat({
            prefix: '',
            clearPrefix: true,
            centsSeparator: ',',
            thousandsSeparator: '.'
        });
    }
}

function remover(id, entity) {
    bootbox.confirm("Deseja remover o registro?", function (confirmed) {
        if (confirmed) {
            $.ajax({
                url: "/" + entity + "/Delete",
                data: { id: id },
                type: 'POST',
                success: function (data) {
                    bootbox.alert(data.Message, function () {
                        if (data.Status == 0) {
                            window.location.href = "/" + entity + "/Index";
                        }
                    });
                },
                error: function (msg) {
                    var title = (/<title>(.*?)<\/title>/m).exec(msg.responseText)[1];
                    bootbox.alert(title);
                }
            });
        }
    });
}