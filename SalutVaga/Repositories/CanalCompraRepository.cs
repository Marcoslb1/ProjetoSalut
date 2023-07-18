using Microsoft.EntityFrameworkCore;
using SalutVaga.Interface;
using SalutVaga.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalutVaga.Repositories
{
    public class CanalCompraRepository : ICanalCompra
    {
        private readonly DB_SALUTContext _dbContext;

        public CanalCompraRepository(DB_SALUTContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<CanalCompra>> SelecionarTodos()
        {
            return await _dbContext.CanalCompra.ToListAsync();
        }
    }
}
