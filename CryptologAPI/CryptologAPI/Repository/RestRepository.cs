using CryptologAPI.Domain;
using Dapper;
using Microsoft.AspNet.OData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace CryptologAPI.Repository
{
    public sealed class RestRepository : IRestRepository
    {
        private readonly string _connectionString;

        public RestRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SensorDataServer");
        }

        //CATEGORIA METHODS
        [EnableQuery()]
        public IEnumerable<Categoria> ListarCategoria()
        {
            using var connection = new SqlConnection(_connectionString);

            var categoriaData = connection.Query<Categoria>("select * from categoria");

            return categoriaData;
        }

        public int InserirCategoria(Categoria cat) 
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "insert into categoria (NOME_CATEGORIA, STATUS)values (@NOME_CATEGORIA, @STATUS)";

            var result = connection.Execute(query, new { NOME_CATEGORIA = cat.NOME_CATEGORIA, STATUS = cat.STATUS });

            return result;
        }

        public int AtualizarCategoria(Categoria cat)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "update categoria set NOME_CATEGORIA = @NOME_CATEGORIA, STATUS = @STATUS where ID_CATEGORIA = @ID_PASSADO";

            var result = connection.Execute(query, new { NOME_CATEGORIA = cat.NOME_CATEGORIA, STATUS = cat.STATUS, ID_PASSADO = cat.ID_CATEGORIA });

            return result;
        }

        public int DeletarCategoria(int ID_CATEGORIA)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "delete from categoria where ID_CATEGORIA = @ID_PASSADO";

            var result = connection.Execute(query, new { ID_PASSADO = ID_CATEGORIA });

            return result;
        }
        //FIM - CATEGORIA METHODS


        //PRODUTO METHODS
        [EnableQuery()]
        public IEnumerable<Produto> ListarProduto()
        {
            using var connection = new SqlConnection(_connectionString);

            var produtoData = connection.Query<Produto>("select * from produtos");

            return produtoData;
        }

        public int InserirProduto(Produto prod)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "insert into produtos (NOME_PRODUTO, DESCRICAO, QUANTIDADE, PREÇO, IMAGEM, ID_CATEGORIA)values (@NOME_PRODUTO, @DESCRICAO, @QUANTIDADE, @PREÇO, @IMAGEM, @ID_CATEGORIA)";

            var result = connection.Execute(query, new { NOME_PRODUTO = prod.NOME_PRODUTO, DESCRICAO = prod.DESCRICAO, QUANTIDADE = prod.QUANTIDADE, PREÇO = prod.PREÇO, IMAGEM = prod.IMAGEM, ID_CATEGORIA = prod.ID_CATEGORIA });

            return result;
        }

        public int DeletarProduto(int ID_PRODUTO)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "delete from produtos where ID_PRODUTO = @ID_PASSADO";

            var result = connection.Execute(query, new { ID_PASSADO = ID_PRODUTO });

            return result;
        }

        public int AtualizarProduto(Produto prod)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "update produtos set NOME_PRODUTO = @NOME_PRODUTO, DESCRICAO = @DESCRICAO, QUANTIDADE = @QUANTIDADE, PREÇO = @PREÇO, ID_CATEGORIA = @ID_CATEGORIA, IMAGEM = @IMAGEM where ID_PRODUTO = @ID_PASSADO";

            var result = connection.Execute(query, new { NOME_PRODUTO = prod.NOME_PRODUTO, DESCRICAO = prod.DESCRICAO, QUANTIDADE = prod.QUANTIDADE, PREÇO = prod.PREÇO, IMAGEM = prod.IMAGEM, ID_CATEGORIA = prod.ID_CATEGORIA, ID_PASSADO = prod.ID_PRODUTO });

            return result;
        }
        //FIM - PRODUTO METHODS

        //USUARIO METHODS
        [EnableQuery()]
        public IEnumerable<Usuario> ListarUsuario()
        {
            using var connection = new SqlConnection(_connectionString);

            var usuarioData = connection.Query<Usuario>("select * from usuarios");

            return usuarioData;
        }

        public int InserirUsuario(Usuario user)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "insert into usuarios (CPF, NOME_USUARIO, EMAIL_USUARIO, SENHA, DATA_NASCIMENTO, PERFIL, TELEFONE)values (@CPF, @NOME_USUARIO, @EMAIL_USUARIO, @SENHA, @DATA_NASCIMENTO, @PERFIL, @TELEFONE)";

            var result = connection.Execute(query, new { CPF = user.CPF, NOME_USUARIO = user.NOME_USUARIO, EMAIL_USUARIO = user.EMAIL_USUARIO, SENHA = user.SENHA, DATA_NASCIMENTO = user.DATA_NASCIMENTO, PERFIL = user.PERFIL, TELEFONE = user.TELEFONE});

            return result;
        }

        public int DeletarUsuario(int ID_USUARIO)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "delete from usuarios where ID_USUARIO = @ID_PASSADO";

            var result = connection.Execute(query, new { ID_PASSADO = ID_USUARIO });

            return result;
        }

        public int AtualizarUsuario(Usuario user)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "update usuarios set CPF = @CPF, NOME_USUARIO = @NOME_USUARIO, EMAIL_USUARIO = @EMAIL_USUARIO, SENHA = @SENHA, DATA_NASCIMENTO = @DATA_NASCIMENTO, PERFIL = @PERFIL, TELEFONE = @TELEFONE where ID_USUARIO = @ID_PASSADO";

            var result = connection.Execute(query, new { CPF = user.CPF, NOME_USUARIO = user.NOME_USUARIO, EMAIL_USUARIO = user.EMAIL_USUARIO, SENHA = user.SENHA, DATA_NASCIMENTO = user.DATA_NASCIMENTO, PERFIL = user.PERFIL, TELEFONE = user.TELEFONE, ID_PASSADO = user.ID_USUARIO });

            return result;
        }
        //FIM - PRODUTO METHODS

    }
}
