using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SalutVaga.DTO;
using SalutVaga.Infra.Procedure;
using SalutVaga.Interface;
using SalutVaga.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SalutVaga.Controllers
{
    public class FormularioController : Controller
    {
        private readonly INotaFiscal _notaFiscal;
        private readonly IProduto _produto;
        private readonly ICanalCompra _canalCompra;
        private string caminhoServidor;
        private IMapper _imapper;

        public FormularioController(INotaFiscal notaFiscal, IProduto produto, ICanalCompra canalCompra, IWebHostEnvironment sistema, IMapper mapper)
        {
            caminhoServidor = sistema.WebRootPath;
            _notaFiscal = notaFiscal;
            _produto = produto;
            _canalCompra = canalCompra;
            _imapper = mapper;
        }

        public async Task<IActionResult> Cadastrar()
        {
            var produtos = await _produto.SelecionarTodos();
            var canaisCompra = await _canalCompra.SelecionarTodos();

            ViewBag.Produtos = produtos.Select(c => new SelectListItem()
            { Text = c.DesProduto, Value = c.IdProduto.ToString() }).ToList();

            ViewBag.CanaisCompra = canaisCompra.Select(c => new SelectListItem()
            { Text = c.DesCanalcompra, Value = c.IdCanalcompra.ToString() }).ToList();

            return View();
        }

        public IActionResult NotaFiscalPopUp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Cadastrar(NotaFiscalDTO notaFiscal, List<ProdutoDTO> produt)
        {
            DateTime min = new DateTime(2023, 05, 01);
            DateTime max = new DateTime(2023, 06, 15);

            if (produt.Count < 6 || (notaFiscal.DtCompra < min || notaFiscal.DtCompra > max))
            {
                return Json(new { redirectToUrl = Url.Action("cadastrar", "Formulario") });

            }
            string caminhoImagem = caminhoServidor + "\\Img\\";
            if(notaFiscal.DesCaminhoAnexo != "" || notaFiscal.DesCaminhoAnexo != null)
            {
                string novoNomeImagem = Guid.NewGuid().ToString() + notaFiscal.DesCaminhoAnexo.Substring(notaFiscal.DesCaminhoAnexo.LastIndexOf(@"\") + 1);

                notaFiscal.DesCaminhoAnexo = caminhoImagem + "_" + novoNomeImagem;
            }


            for (int i = 0; i < produt.Count; i++)
            {
                notaFiscal.Quantidade = produt[i].quantidade;
                notaFiscal.CodProduto = produt[i].nomeProduto;

                NotaFiscalProcedure.InserirNota(notaFiscal);
            }
            return Json(new { redirectToUrl = Url.Action("cadastrar", "Formulario") });
        }
    }
}
