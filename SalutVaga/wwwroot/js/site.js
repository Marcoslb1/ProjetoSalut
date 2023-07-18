$(document).ready(function () {

    //Modal bootstrap
    $(".btn-notafiscalpopup").click(function () {
        var id = $(this).data("value")
        $("#conteudoModalNFPopUp").load("/Formulario/NotaFiscalPopup", function () {
            $("#ModalNFPopUp").modal("show");
        });
    })

    //Mascara cnpj
    $("#DesCnpj").mask("00.000.000/0000-00")
});
