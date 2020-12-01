using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptologAPI.Domain
{
    public sealed class Categoria
    {
        public int ID_CATEGORIA { get; set; }

        public string NOME_CATEGORIA { get; set; }

        public Boolean STATUS { get; set; }
    }
}
