using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_inLockCodeFirst_webApi.Domains
{
    /// <summary>
    /// Classe representa a entidade Estudios
    /// </summary>

    //Define o nome da tabela
    [Table("Estudio")]
    //Defineque que o atributo NomeEstudio é unico, ou seja não deve existir outro igual.
    [Index(nameof(nomeEstudio), IsUnique = true)]
    public class Estudio
    {
        //  Define a chave primária
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid idEstudio { get; set; }

        //  Define o nome da coluna e o tipo de dado
        [Column(TypeName = "VARCHAR(150)")]
        //  Define que o atributo é obrigatorio
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string nomeEstudio { get; set; }

        //  ? permite nulo neste campo, fazendo com que no metodo post do controller não precise ser informado.
        public List<Jogo>? jogo { get; set; }
    }
}
