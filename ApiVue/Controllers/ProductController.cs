using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVue.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiVue.Controllers
{
    [Route("api/product")]
    [EnableCors("Politica")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var product = new List<Product>()
            {
                new Product("Bola de Basquete","http://avodistribuidora.com.br/wp-content/uploads/2017/10/penalty-oficialfeminino-2.jpg"),
                new Product("Galinha Pintadinha", "http://2.bp.blogspot.com/-vq_eK8-1ops/T9eBBMOBLvI/AAAAAAAAFiA/xRAHrYEqM_8/s320/Galinha-Pintadinha-png-Queroimagem.com+%281%29.png")
            };
            return new ObjectResult(product);
        }
    }
}