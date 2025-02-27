using api_filmes_senai.Controllers;
using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{
    /// <summary>
    /// Interface para Genero : Contrato
    /// Toda classe que herdar(implementar) essa interface,dever implementar todos os metodos definidos aqui dentro
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD : Métodos
        //C : Create : Cadastrar um novo Objeto
        //R : Read : Listar todos os objetos
        //U : Uptade : Alterar um objeto
        //D : Delete : DEleto ou excluo um objeto

        // Método = TipoDeRetorno NomeDoMetodo(Argumentos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Deletar(Guid id);

        Genero BuscarPorId(Guid id);
        void Cadastrar(GeneroController novoGenero);
    }
}
