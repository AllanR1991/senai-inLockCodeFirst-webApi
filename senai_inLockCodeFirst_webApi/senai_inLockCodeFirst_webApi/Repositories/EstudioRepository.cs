using Microsoft.EntityFrameworkCore;
using senai_inLockCodeFirst_webApi.Contexts;
using senai_inLockCodeFirst_webApi.Domains;
using senai_inLockCodeFirst_webApi.Interfaces;

namespace senai_inLockCodeFirst_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio dos Estudio
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Instanciando Objeto ctx do tipo InLockContext por onde serão chamados os métodos do EF Core.
        /// </summary>
        InLockContext ctx = new InLockContext();


        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">ID do estudio que sera atualizado</param>
        /// <param name="estudioAtualizado">Objeto do tipo Estudio contendo os dados alterados</param>
        public void Atualizar(Guid id, Estudio estudioAtualizado)
        {
            // Busca um estúdio através do id
            Estudio estudioBuscado = ctx.Estudio.Find(id)!;
            //A exclamação (!) é um operador que indica que o valor não é nulo. Ele é usado para informar ao compilador que você tem certeza de que a variável ou a expressão não é nula e que pode acessar suas propriedades ou métodos sem problemas. No seu caso, você está usando o operador de atualização (!) para atualizar o objeto estudioBuscado, que pode ser nulo. Isso significa que você está garantindo ao compilador que estudioBuscado não é nulo e que pode ser atualizado sem causar um erro. Se você não usar o operador de atualização, o compilador pode gerar um aviso de que você está tentando atualizar um valor que pode ser nulo1.

            // Verifica se o nome do estúdio foi informado
            if (estudioAtualizado.nomeEstudio != null)
            {
                // Atribui os novos valoes aos campos existentes
                estudioBuscado.nomeEstudio = estudioAtualizado.nomeEstudio;
            }

            // Atualiza o estúdio que foi buscado
            ctx.Estudio.Update(estudioBuscado!);
            //A exclamação (!) é um operador que indica que o valor não é nulo. Ele é usado para informar ao compilador que você tem certeza de que a variável ou a expressão não é nula e que pode acessar suas propriedades ou métodos sem problemas. No seu caso, você está usando o operador de atualização (!) para atualizar o objeto estudioBuscado, que pode ser nulo. Isso significa que você está garantindo ao compilador que estudioBuscado não é nulo e que pode ser atualizado sem causar um erro. Se você não usar o operador de atualização, o compilador pode gerar um aviso de que você está tentando atualizar um valor que pode ser nulo1.

            //Salva as informações para serem gravadas no banco de dados.
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um estúdio através do seu ID
        /// </summary>
        /// <param name="id">Id do estudio que será buscado</param>
        /// <returns>Um estudio buscado</returns>
        public Estudio BuscarPorID(Guid id)
        {
            // Retorna o primeiro esstudio encontrado para o ID informado
                                               // O lambda cria um objeto da entidade Estudio                         
            return ctx.Estudio.FirstOrDefault(e => e.idEstudio == id);
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto do tipo Estudio com as novas informações</param>
        public void Cadastrar(Estudio novoEstudio)
        {
            // Adiciona este novoEstudio
            //novoEstudio.idEstudio = Guid.NewGuid();
            ctx.Estudio.Add(novoEstudio);

            //Salva as informações para serem gravadas no banco de dados.
            ctx.SaveChanges();

        }


        /// <summary>
        /// Deleta um estudio existente
        /// </summary>
        /// <param name="id">Id do estudio que será Deletado.</param>
        public void Deletar(Guid id)
        {
            // Busca um estudio atraves do seu id
            Estudio estucioBuscado = ctx.Estudio.Find(id);

            // Remode o estudio encontado
            ctx.Estudio.Remove(estucioBuscado);

            //Salva a informação
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Lista de estúdio</returns>
        public List<Estudio> Listar()
        {
            return ctx.Estudio.ToList();
        }

        /// <summary>
        /// Listas todos os Estudio com os seus respectivos jogos.
        /// </summary>
        /// <returns>Lista de Estudio com seus jogos</returns>
        public List<Estudio> ListarJogos()
        {
            // Retorna uma lista de Estudio com seus jogos.
            return ctx.Estudio.Include(e => e.jogo).ToList();
        }
    }
}
