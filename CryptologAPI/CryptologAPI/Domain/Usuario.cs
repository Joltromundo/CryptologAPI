using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptologAPI.Domain
{
    public sealed class Usuario
    {
        public int ID_USUARIO { get; set; }

        public string CPF { get; set; }

        public string NOME_USUARIO { get; set; }

        public string EMAIL_USUARIO { get; set; }

        public string SENHA { get; set; }

        public string DATA_NASCIMENTO { get; set; }

        public string PERFIL { get; set; }

        public string TELEFONE { get; set; }
    }
}
