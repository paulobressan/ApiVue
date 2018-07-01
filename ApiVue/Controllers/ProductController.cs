using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVue.Model;
using ApiVue.Reposity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiVue.Controllers
{
    [Route("api/product")]
    [EnableCors("Politica")]
    public class ProductController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public IProdutoRepository ProdutoRepository => _produtoRepository;

        public ProductController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await ProdutoRepository.SelecionarTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            try
            {
                return Ok(await ProdutoRepository.Inserir(produto));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro de banco de dados");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Produto produto)
        {
            try
            {
               return Ok(await _produtoRepository.Alterar(produto));
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro ao atualizar produto");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await ProdutoRepository.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro de banco de dados");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var produto = await ProdutoRepository.SelecionarPorId(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Não foi possivel buscar o produto.");
            }
        }
    }
}