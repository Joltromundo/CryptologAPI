using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptologAPI.Domain;
using CryptologAPI.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptologAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IRestRepository _produtoRepository;

        public ProdutoController(ILogger<ProdutoController> logger, IRestRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }


        [HttpGet]
        [EnableQuery()]
        public IActionResult GetAllData()
        {
            try
            {
                var data = _produtoRepository.ListarProduto();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter dados");
                return new StatusCodeResult(500);
            }
        }
        
        [HttpPost]
        public IActionResult SetData([FromForm] Produto prod)
        {
            try
            {
                var result = _produtoRepository.InserirProduto(prod);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateData([FromForm] Produto prod)
        {
            try
            {
                var result = _produtoRepository.AtualizarProduto(prod);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteData([FromForm] int ID_PRODUTO)
        {
            try
            {
                var result = _produtoRepository.DeletarProduto(ID_PRODUTO);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }
    }
}
