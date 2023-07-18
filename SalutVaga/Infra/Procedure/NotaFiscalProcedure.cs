using System.Data;
using System;
using SalutVaga.DTO;
using Dapper;
using SalutVaga.Models;

namespace SalutVaga.Infra.Procedure
{
    public class NotaFiscalProcedure
    {
        public static void InserirNota(NotaFiscalDTO notaFiscal)
        {
            var Param = new DynamicParameters();
            Param.Add("@des_cnpj", notaFiscal.DesCnpj);
            Param.Add("@cod_canalcompra", notaFiscal.CodCanalcompra );
            Param.Add("@dt_compra", notaFiscal.DtCompra );
            Param.Add("@des_notafiscal", notaFiscal.DesNotafiscal );
            Param.Add("@quantidade", notaFiscal.Quantidade);
            Param.Add("@des_caminhoAnexo", notaFiscal.DesCaminhoAnexo);
            Param.Add("@cod_produto", notaFiscal.CodProduto);


            using (var Con = SingleConnection.GetConnection("DefaultConnection"))
            {
                try
                {
                    Con.Query<NotaFiscalDTO>("dbo.SP_SALUT_INS_NOTAFISCAL", Param, commandType: CommandType.StoredProcedure, commandTimeout: 120);
                }

                catch (Exception sql)
                {
                    //throw;
                }
            }
        }
    }
}
