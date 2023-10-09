using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using senai_inLockCodeFirst_webApi.Domains;

namespace senai_inLockCodeFirst_webApi.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto.
    /// Faz a comunicação entre a API eo banco de dados.
    /// </summary>
    
    public class InLockContext : DbContext
    {
        //  Define as  entidades do banco de dados
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        /// <summary>
        /// Define as configurações de construção do banco de dados.
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  Definição da string de conexão
            optionsBuilder.UseSqlServer("Server = ALLANR1991-DESK\\SQLEXPRESS; Database = InLock_CodeFirst; User Id = sa; pwd = 123456; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);

        }

        //InLockContext con = new InLockContext();
        

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Inserção do DML
            
            Guid Adm, Cli, Blizzard, RockstarStudios;
                        
            modelBuilder.Entity<TipoUsuario>().HasData(
                new TipoUsuario
                {
                    idTipoUsuario = Adm = Guid.NewGuid(),
                    titulo = "Administrador"
                },
                new TipoUsuario
                {
                    idTipoUsuario = Cli =  Guid.NewGuid(),
                    titulo = "Cliente"                    
                }
            );

            modelBuilder.Entity<Estudio>().HasData(
                new Estudio
                {
                    idEstudio = Blizzard =  Guid.NewGuid(),
                    nomeEstudio = "Blizzard"                    
                },
                new Estudio
                {
                    idEstudio = RockstarStudios =  Guid.NewGuid(),
                    nomeEstudio = "Rockstar Studios"
                },
                new Estudio
                {
                    idEstudio = Guid.NewGuid(),
                    nomeEstudio = "Square Enix"                    
                }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    idUsuario = Guid.NewGuid(),
                    email = "admin@admin.com",
                    senha = "admin",
                    idTipoUsuario = Adm
                },
                new Usuario
                {
                    idUsuario = Guid.NewGuid(),
                    email = "cliente@cliente.com",
                    senha = "cliente",
                    idTipoUsuario = Cli
                }
                );

            modelBuilder.Entity<Jogo>().HasData(
                new Jogo
                {
                    idJogo = Guid.NewGuid(),
                    dataLancamento = DateTime.Parse("2012-05-15"),
                    descricao = "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.",
                    nomeJogo = "Diablo 3",
                    idEstudio = Blizzard,
                    valor = 99.00M
                },
                new Jogo
                {
                    idJogo = Guid.NewGuid(),
                    dataLancamento = DateTime.Parse("2018-10-26"),
                    descricao = "Jogo eletrônico de ação-aventura western.",
                    nomeJogo = "Red Dead Redemption II",
                    idEstudio = RockstarStudios,
                    valor = 120.00M
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
