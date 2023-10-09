using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_inLockCodeFirst_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade TipoUsuario.
    /// </summary>    

    //  [Table("TipoUsuario")] -> Definindo o nome da tabela que será criada no banco de dados, utilizando DataAnnotations.
    [Table("TipoUsuario")]
    [Index(nameof(titulo), IsUnique = true)]
    public class TipoUsuario
    {
        [Key]   //  Definindo Primary Key com DataAnnotations
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //  Define o autoincremento  
        public Guid idTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(255)")] //  Define o tipo de dado
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório.")] //  Define que a propriedade é obrigatória.
        public string titulo { get; set; }
    }
}
