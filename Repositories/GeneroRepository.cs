using api_filmes_senai.Context;
using api_filmes_senai.Controllers;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Repositories
{
    /// <summary>
    /// Classe que vai implementara interface IGeneroRepository
    /// ou seja vamos implementar os metodos, toda a logiaca dos metodos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// Váriavel privada e somente leitura que "Guarda os dados do contexto"
        /// </summary>
        private readonly Filmes_Context _context;
        /// <summary>
        /// Construtor do répositorio
        /// Aqui, toda vez que o construtor for chamado,
        /// os dados estarão disponiveis
        /// </summary>
        /// <param name="contexto"></param>
        public GeneroRepository(Filmes_Context contexto)
        {
            _context = contexto;  
        }

        public void Atualizar(Guid id, Genero genero)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                if (generoBuscado != null)
                {
                    generoBuscado.Nome = genero.Nome;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Genero BuscarPorId(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                return generoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Método para cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">objeto gênero a ser cadastrado</param>

        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                //Adiciona um novo gênero na tabela Generos(BD)
                _context.Genero.Add(novoGenero);
                //Após o cadastro, salva as alterações(BD)
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(GeneroController novoGenero)
        {
            throw new NotImplementedException();
        }

        public List<Genero> Listar()
        {
            try
            {
                List<Genero> ListaGeneros = _context.Genero.ToList();

                return ListaGeneros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
            Genero generoBuscado = _context.Genero.Find(id)!;

            if (generoBuscado != null)
            {
                _context.Genero.Remove(generoBuscado);      
            }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
