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
        public ProductController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _produtoRepository.SelecionarTodos());
            //var product = new List<Produto>()
            //{
            //    new Produto("Bola de Basquete","http://avodistribuidora.com.br/wp-content/uploads/2017/10/penalty-oficialfeminino-2.jpg"),
            //    new Produto("Galinha Pintadinha", "http://2.bp.blogspot.com/-vq_eK8-1ops/T9eBBMOBLvI/AAAAAAAAFiA/xRAHrYEqM_8/s320/Galinha-Pintadinha-png-Queroimagem.com+%281%29.png")
            //};
            //return new ObjectResult(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            try
            {
                return Ok(await _produtoRepository.Inserir(produto));

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro de banco de dados");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _produtoRepository.Remover(id);
                return Ok();

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro de banco de dados");
            }
        }
    }
}