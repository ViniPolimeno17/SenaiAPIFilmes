using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository; 
        }
        /// <summary>
        /// Endpoint para Cadastrar um novo Usuario
        /// </summary>
        /// <param name="usuario">Cadastrar um novo Usuario</param>
        /// <returns>Cadastrar um novoUsuario</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar o id do Usuario
        /// </summary>
        /// <param name="id">Buscar id do Usuario</param>
        /// <returns>buscar pelo id do usuario</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                if (usuarioBuscado != null)
                {
                   return Ok(usuarioBuscado);  
                }
                return null!;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        //[HttpGet("BuscarPorEmailESenha")]

        //public IActionResult GetByEmailAndSenha(UsuarioDTO usuario)
        //{
        //    try
        //    {
        //        Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

        //        if (usuarioBuscado != null)
        //        {
        //           return Ok(usuarioBuscado);   
        //        }
        //        return null!;
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}
    }
}
