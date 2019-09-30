using System.ComponentModel.DataAnnotations;

namespace DesafioPagueVeloz.DAL.Models
{
    public class Telefone
    {
        public int Id { get; set; }

        [Required]
        public string NumeroTelefone { get; set; }

        [Required]
        public int FornecedorId { get; set; }
    }
}
