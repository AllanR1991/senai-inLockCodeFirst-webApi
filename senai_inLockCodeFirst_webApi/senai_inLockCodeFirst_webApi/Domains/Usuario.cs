using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace senai_inLockCodeFirst_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Usuarios.
    /// </summary>

    //  Define o nome da tabela que será criada no banco de dados.
    [Table("Usuario")]
    [Index(nameof(email), IsUnique = true)]
    public class Usuario
    {
        //  Define que será uma chave primária.
        [Key]

        //  Define o auto-incremento
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idUsuario { get; set; }

        //  Define o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]

        //  Define que a propriedade é obrigatória.
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        public string email { get; set; }

        //  Define o tipo de dados.
        [Column(TypeName = "VARCHAR(150)")]
        //  Define que a propriedade é obrigatória.
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        //  Define os requisitos da propriedade.
        [StringLength(30,MinimumLength = 5, ErrorMessage = " A senha deve conter entre 5 e 30 Caracteres.")]
        public string senha { get; set; }


        // Não é necessário inserir [Column(TypeName = "INT")], pois a propriedade ja esta como inteiro e o banco de dados ja  reconhece nativamente.
        public Guid idTipoUsuario { get; set; }

        //  Definindo a chave estrangeira.
        [ForeignKey("idTipoUsuario")]
        public TipoUsuario tipoUsuario { get; set; }
    }
}
