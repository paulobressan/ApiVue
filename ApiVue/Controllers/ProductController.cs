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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (ProdutoRepository repository = new ProdutoRepository())
            {
                return Ok(await repository.SelecionarTodos());
            }
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
            using (ProdutoRepository repository = new ProdutoRepository())
            {
                try
                {
                    return Ok(await repository.Inserir(produto));

                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Erro de banco de dados");
                }
            }
        }
    }
}