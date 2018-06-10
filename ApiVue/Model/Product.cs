using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVue.Model
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string nome, string url)
        {
            this.Nome = nome;
            this.Url = url;
        }

        public string Nome { get; set; }
        public string Url { get; set; }
    }
}
