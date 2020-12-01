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
    public class CategoriaController : ControllerBase
    {

        private readonly ILogger<CategoriaController> _logger;
        private readonly IRestRepository _categoriaRepository;

        public CategoriaController(ILogger<CategoriaController> logger, IRestRepository categoriaRepository)
        {
            _logger = logger;
            _categoriaRepository = categoriaRepository;
        }


        [HttpGet]
        [EnableQuery()]
        public IActionResult GetAllData()
        {
            try
            {
                var data = _categoriaRepository.ListarCategoria();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromForm] Categoria cat)
        {
            try
            {
                var result = _categoriaRepository.InserirCategoria(cat);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }

        }

        [HttpPut]
        public IActionResult UpdateData([FromForm] Categoria cat)
        {
            try
            {
                var result = _categoriaRepository.AtualizarCategoria(cat);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteData([FromForm] int ID_CATEGORIA)
        {
            try
            {
                var result = _categoriaRepository.DeletarCategoria(ID_CATEGORIA);

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
