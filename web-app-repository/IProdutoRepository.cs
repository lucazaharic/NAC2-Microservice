using MyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> BuscarProdutoAsync(int id);
        Task<IEnumerable<Produto>> ListarProdutosAsync();
        Task SalvarProdutoAsync(Produto produto);
        Task AtualizarProdutoAsync(Produto produto);
        Task DeletarProdutoAsync(int id);
    }
}

