using System.ComponentModel.DataAnnotations;

namespace DesafioPagueVeloz.DAL.Models
{
    public class Empresa
    {
        [Key]
        public string CNPJ { get; set; }

        [Required]
        public string NomeFantasia { get; set; }

        [Required]
        public string UF { get; set; }
    }
}
