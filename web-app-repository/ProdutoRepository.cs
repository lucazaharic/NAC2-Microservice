using Dapper;
using MyApp.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyApp.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _connection;

        public ProdutoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Produto> BuscarProdutoAsync(int id)
        {
            var query = "SELECT * FROM Produtos WHERE Id = @id";
            return await _connection.QueryFirstOrDefaultAsync<Produto>(query, new { id });
        }

        public async Task<IEnumerable<Produto>> ListarProdutosAsync()
        {
            var query = "SELECT * FROM Produtos";
            return await _connection.QueryAsync<Produto>(query);
        }

        public async Task SalvarProdutoAsync(Produto produto)
        {
            var query = "INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)";
            await _connection.ExecuteAsync(query, produto);
        }

        public async Task AtualizarProdutoAsync(Produto produto)
        {
            var query = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco WHERE Id = @Id";
            await _connection.ExecuteAsync(query, produto);
        }

        public async Task DeletarProdutoAsync(int id)
        {
            var query = "DELETE FROM Produtos WHERE Id = @id";
            await _connection.ExecuteAsync(query, new { id });
        }
    }
}

