using Microsoft.EntityFrameworkCore;
using SalutVaga.Interface;
using SalutVaga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalutVaga.Repositories
{
    public class ProdutoRepository : IProduto
    {
        private readonly DB_SALUTContext _context;

        public ProdutoRepository(DB_SALUTContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> SelecionarTodos()
        {
            return await _context.Produto.ToListAsync();
        }
    }
}
