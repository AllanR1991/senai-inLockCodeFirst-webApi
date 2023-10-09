using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace senai_inLockCodeFirst_webApi.Domains
{
    /// <summary>
    /// Classe que representa e entidade Jogo
    /// </summary>
    /// 

    //  Define o nome da tabela que sera criada no banco de dados.
    [Table("Jogo")]
    [Index(nameof(nomeJogo), IsUnique = true)]
    public class Jogo
    {
        [Key]
        public Guid idJogo { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string nomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string descricao { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime dataLancamento { get; set; }

        [Column(TypeName = "SMALLMONEY")]
        [Required(ErrorMessage = "É necessario informar o preço do jogo!")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "É necessario informar o estúdio que produziu o jogo!")]
        public Guid idEstudio { get; set; }

        //  Define a chave estrangeira
        [ForeignKey("idEstudio")]
        public Estudio estudio { get; set; }
    }
}
