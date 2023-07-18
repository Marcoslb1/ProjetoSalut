using SalutVaga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalutVaga.Interface
{
    public interface IProduto
    {
        public Task<IEnumerable<Produto>> SelecionarTodos();
    }
}
