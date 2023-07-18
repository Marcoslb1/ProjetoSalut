using Microsoft.EntityFrameworkCore;
using SalutVaga.Interface;
using SalutVaga.Models;

namespace SalutVaga.Repositories
{
    public class NotaFiscalRepository : INotaFiscal
    {
        private readonly DB_SALUTContext _dbContext;

        public NotaFiscalRepository(DB_SALUTContext context)
        {
            _dbContext = context;
        }

        public void Incluir(NotaFiscal notaFiscal)
        {
            _dbContext.NotaFiscal.Add(notaFiscal);
        }
    }
}
