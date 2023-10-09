using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inLockCodeFirst_webApi.Domains;
using senai_inLockCodeFirst_webApi.Interfaces;
using senai_inLockCodeFirst_webApi.Repositories;

namespace senai_inLockCodeFirst_webApi.Controllers
{
    // Define que o tipo de resposta da Api será no formato JSON
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/apli/estudio
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        /// <summary>
        /// Objeto chamado _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository {  get; set; }

        /// <summary>
        /// Instancia o objeto _estudioRepository para que haja a referencia nos metodos implementados no repositorio Estudio.
        /// </summary>
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Uma lista de estudio</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método.
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// Busca um estúdio através do seu ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            // Retorna a resposta da requisção fazendo a chamada para o método.
            return Ok(_estudioRepository.BuscarPorID(id));
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto tipo Estudio que será cadastrado</param>
        /// <returns>Status code 201 Created</returns>
        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            //Faz a chamada para o metodo
            _estudioRepository.Cadastrar(novoEstudio);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">Id do estúdio que será atualziado</param>
        /// <param name="estudioAlterado">Objeto tipo estudio contendo as novas informações</param>
        /// <returns>Status code 204 NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,Estudio estudioAlterado) 
        {
            //Faz a chamada para o metodo
            _estudioRepository.Atualizar(id, estudioAlterado);
            return NoContent();
        }

        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="id">Id do ususario a ser deletado</param>
        /// <returns>Status Code 204 NotContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //Faz chamada para o metodo
            _estudioRepository.Deletar(id);
            // retorna um status code
            return NoContent();
        }

        /// <summary>
        /// Lista todos os estudio com seus respectivos jogos
        /// </summary>
        /// <returns>Uma lista de estudios com os jogos e um status code 200 - OK</returns>
        [HttpGet("jogos")]
        public IActionResult GetGames()
        {
            //Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_estudioRepository.ListarJogos());
        }
    }
}
