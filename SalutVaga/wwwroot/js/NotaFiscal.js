class NotaFiscal {
    constructor() {

    }

    salvar() {
        let notaFiscal = this.lerDados();
        var i = false

        if (this.validaCampos(notaFiscal) && this.validaProdutos() && this.validaDatas(notaFiscal)) {
            i = true
        }

        return i 
    }

    lerDados() {
        let notaFiscal = {}
        notaFiscal.DesCnpj = document.querySelector('#DesCnpj').value;
        notaFiscal.CodCanalcompra = document.querySelector('#CodCanalcompra').value;
        notaFiscal.DesNotaFiscal = document.querySelector('#DesNotaFiscal').value;
        notaFiscal.dtCompra = document.querySelector('#dtCompra').value;

        return notaFiscal
    }

    validaCampos(notaFiscal) {
        let msg = ''

        if (notaFiscal.DesCnpj == '') {
            msg += '- Informe o CNPJ \n';
        }
        if (notaFiscal.CodCanalcompra == '') {
            msg += '- Informe o Canal de Compra \n';
        }
        if (notaFiscal.DesNotaFiscal == '') {
            msg += '- Informe a Nota Fiscal \n';
        }
        if (notaFiscal.dtCompra == '') {
            msg += '- Informe a Data de compra\n';
        }

        if (msg != '') {
            alert(msg);
            return false;
        }
        return true;
    }
    validaProdutos() {
        if (produto.arrayProdutos.length < 6) {
            alert('Insira no minimo 6 produtos para enviar')
            return false;
        }
        return true;
    }

    validaDatas(notaFiscal) {
        let msg = ''

        if (notaFiscal.dtCompra < '2023-05-01' || notaFiscal.dtCompra > '2023-06-15') {
            msg += '- Insira uma data entre 01/05/2023 e 15/06/2023\n';
        }

        if (msg != '') {
            alert(msg);
            return false;
        }
        return true;
    }
}

var Nf = new NotaFiscal();