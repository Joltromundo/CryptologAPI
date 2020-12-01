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
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IRestRepository _usuarioRepository;

        public UsuarioController(ILogger<UsuarioController> logger, IRestRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }


        [HttpGet]
        [EnableQuery()]
        public IActionResult GetAllData()
        {
            try
            {
                var data = _usuarioRepository.ListarUsuario();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromForm] Usuario user)
        {
            try
            {
                var result = _usuarioRepository.InserirUsuario(user);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        public IActionResult UpdateData([FromForm] Usuario user)
        {
            try
            {
                var result = _usuarioRepository.AtualizarUsuario(user);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        public IActionResult DeleteData([FromForm] int ID_USUARIO)
        {
            try
            {
                var result = _usuarioRepository.DeletarUsuario(ID_USUARIO);

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
