using CryptologAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptologAPI.Repository
{
    public interface IRestRepository
    {   
        //CATEGORIA
        public IEnumerable<Categoria> ListarCategoria();

        public int InserirCategoria(Categoria cat);

        public int AtualizarCategoria(Categoria cat);

        public int DeletarCategoria(int ID_CATEGORIA);
        //FIM - CATEGORIA

        //PRODUTO
        public IEnumerable<Produto> ListarProduto();

        public int InserirProduto(Produto prod);

        public int AtualizarProduto(Produto prod);

        public int DeletarProduto(int ID_PRODUTO);
        //FIM - PRODUTO

        //USUARIO
        public IEnumerable<Usuario> ListarUsuario();

        public int InserirUsuario(Usuario user);

        public int AtualizarUsuario(Usuario user);

        public int DeletarUsuario(int ID_USUARIO);
        //FIM - USUARIO
    }
}
