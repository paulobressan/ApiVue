using ApiVue.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVue.Reposity
{
    public class ProdutoRepository : IDisposable, IProdutoRepository
    {
        IDbConnection _context;
        public ProdutoRepository()
        {
            _context = new MySqlConnection("server=localhost;user id=root;password=2cnbrf4642;persistsecurityinfo=True;port=3306;database=vue;SslMode=none");
        }

        public async Task<List<Produto>> SelecionarTodos()
        {
            var result = await _context.QueryAsync<Produto>("select * from produto", null);
            return result.ToList();
        }

        public async Task<Produto> Inserir(Produto produto)
        {
            var result = await _context.QueryAsync<Produto>(@"insert into produto (nome, url) values (@nome, @url);" +
                "select * from produto where id = (select last_insert_id() as id);", produto);
            return result.Single();
        }

        public async Task Remover(int id)
        {
            await _context.QueryAsync<Produto>(@"delete from produto where id = @id", new { id });
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
