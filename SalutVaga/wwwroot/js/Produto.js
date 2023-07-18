class Produto {
    constructor() {
        this.arrayProdutos = [];
    }

    salvar() {
        let produto = this.lerDados();
        if (this.validaCampos(produto)) {
            this.adicionar(produto);
        }

        this.listaTabela() 
        this.limpar()
    }
    deletarArray() {
        this.arrayProdutos = []
    }

    deletar(produto) {
        for (let i = 0; i < this.arrayProdutos.length; i++) {
            if (this.arrayProdutos[i].nomeProduto = produto) {
                this.arrayProdutos.splice(i, 1);
                let tbody = document.getElementById('tbody')
                tbody.deleteRow(i);
            }
        }
    }

    listaTabela() {
        let tbody = document.getElementById('tbody')
        tbody.innerText = '';

        for (let i = 0; i < this.arrayProdutos.length; i++) {
            let tr = tbody.insertRow();

            let td_produto = tr.insertCell();
            let td_quantidade = tr.insertCell();
            let td_deletar = tr.insertCell();

            td_produto.innerText = this.arrayProdutos[i].nomeProduto;
            td_quantidade.innerText = this.arrayProdutos[i].quantidade;

            td_produto.classList.add('center');
            td_quantidade.classList.add('center');

            let imgDeletar = document.createElement('img');
            imgDeletar.setAttribute("onclick", "produto.deletar(" + this.arrayProdutos[i].nomeProduto+")")
            imgDeletar.src = 'Img/deletar.svg'

            td_deletar.appendChild(imgDeletar);
        }
    }

    limpar() {
        produto.nomeProduto = document.getElementById('IdProduto').value = ''
        produto.quantidade = document.getElementById('quantidade').value = ''
    }

    adicionar(produto) {
        this.arrayProdutos.push(produto);
        this.id++;
    }

    lerDados() {
        let produto = {}
        produto.nomeProduto = document.getElementById('IdProduto').value;
        produto.quantidade = document.getElementById('quantidade').value;

        return produto
    }

    validaCampos(produto) {
        let msg = ''

        if (produto.quantidade == '') {
            msg += '- Informe a quantidade de produtos \n';
        }
        if (produto.nomeProduto == '') {
            msg += '- Informe o produto \n';
        }

        if (msg != '') {
            alert(msg);
            return false;
        }
        return true;
    }
}

var produto = new Produto();