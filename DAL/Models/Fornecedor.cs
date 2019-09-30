using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioPagueVeloz.DAL.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CPF / CNPJ
        /// </summary>
        [Required]
        public string Documento { get; set; }

        public string RG { get; set; }

        public DateTime? DataNascimento { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public Empresa Empresa { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
    }
}
