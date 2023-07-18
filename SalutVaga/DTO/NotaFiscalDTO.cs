using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SalutVaga.DTO
{
    public class NotaFiscalDTO
    {
        public string DesCnpj { get; set; }
        public int CodCanalcompra { get; set; }
        public DateTime DtCompra { get; set; }
        public string DesNotafiscal { get; set; }
        public int CodProduto { get; set; }
        public int Quantidade { get; set; }
        public string DesCaminhoAnexo { get; set; }
    }
}
