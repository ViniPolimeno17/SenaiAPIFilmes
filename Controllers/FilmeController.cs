using api_filmes_senai.Context;
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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        
        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }
        /// <summary>
        /// Endpoint para Listar os filmes
        /// </summary>
        /// <returns>Listar filmes</returns>
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filme> listaDeFilmes = _filmeRepository.Listar();

                return Ok(listaDeFilmes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint para Cadastrar um novo Filme
        /// </summary>
        /// <param name="novoFilme">Cadastrar um novo Filme</param>
        /// <returns>Cadastrar um novoFilme</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint para buscar um Filme pelo Id
        /// </summary>
        /// <param name="id">Id do Filme buscado</param>
        /// <returns>Filme Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmeBuscado = _filmeRepository.BuscarPorId(id);

                return Ok(filmeBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint para Atualizar um Filme
        /// </summary>
        /// <param name="id">Atualizar um Filme</param>
        /// <param name="filme">Atualizar um Filme</param>
        /// <returns>Atualizar um filme</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Filme filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);

                return NoContent();
            }

            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint para cadastrar um novo Filme
        /// </summary>
        /// <param name="id">Cadastrar um novo Filme</param>
        /// <returns>Deletar um filme</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint para listar por genero um Filme
        /// </summary>
        /// <param name="id">Listar por genero um Filme</param>
        /// <returns>lista por genero um Filme</returns>
        [HttpGet("ListarPorGenero/{id}")]

        public IActionResult GetByGenero(Guid id) 
        {
            try
            {
                List<Filme> listaDeFilmePorGenero = _filmeRepository.ListarPorGenero(id);

                return Ok(listaDeFilmePorGenero);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
