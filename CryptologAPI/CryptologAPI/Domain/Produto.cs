using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptologAPI.Domain
{
    public sealed class Produto
    {
        public int ID_PRODUTO { get; set; }

        public string NOME_PRODUTO { get; set; }

        public string DESCRICAO { get; set; }

        public long QUANTIDADE { get; set; }

        public decimal PREÇO { get; set; }

        public string IMAGEM { get; set; }

        public int ID_CATEGORIA { get; set; }
    }
}
