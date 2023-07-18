using SalutVaga.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalutVaga.Interface
{
    public interface ICanalCompra
    {
        public Task<IEnumerable<CanalCompra>> SelecionarTodos();
    }
}
