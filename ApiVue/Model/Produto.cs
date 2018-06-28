using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVue.Model
{
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(string nome, string url)
        {
            this.Nome = nome;
            this.Url = url;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}
