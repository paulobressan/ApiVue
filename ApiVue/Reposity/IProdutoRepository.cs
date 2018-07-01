using ApiVue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVue.Reposity
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> SelecionarTodos();
        Task<Produto> Inserir(Produto produto);
        Task<Produto> Alterar(Produto produto);
        Task Remover(int id);
        Task<Produto> SelecionarPorId(int id);
    }
}
