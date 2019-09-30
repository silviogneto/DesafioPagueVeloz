using System;
using System.Linq;
using DesafioPagueVeloz.DAL;
using DesafioPagueVeloz.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioPagueVeloz.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FornecedoresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.FornecedorRepository.GetAll(include: x => x.Include(i => i.Empresa).Include(i => i.Telefones)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fornecedor fornecedor)
        {
            var novoFornecedor = new Fornecedor
            {
                Empresa = fornecedor.Empresa,
                Nome = fornecedor.Nome,
                Documento = fornecedor.Documento,
                DataCadastro = DateTime.Now
            };

            if (fornecedor.Telefones != null)
            {
                novoFornecedor.Telefones = fornecedor.Telefones.Select(x => new Telefone { NumeroTelefone = x.NumeroTelefone }).ToList();
            }

            if (!string.IsNullOrWhiteSpace(fornecedor.RG) && fornecedor.DataNascimento.HasValue)
            {
                novoFornecedor.RG = fornecedor.RG;
                novoFornecedor.DataNascimento = fornecedor.DataNascimento;

                if (novoFornecedor.Empresa.UF == "PR" && CalcularIdade(novoFornecedor.DataNascimento.Value) < 18)
                    return BadRequest("Menores de idade não podem ser fornecedores do Paraná");
            }

            _unitOfWork.EmpresaRepository.Attach(novoFornecedor.Empresa);
            _unitOfWork.FornecedorRepository.Add(novoFornecedor);
            _unitOfWork.Save();

            return Ok();
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;

            if (dataNascimento.Month > DateTime.Now.Month ||
                (dataNascimento.Month == DateTime.Now.Month && dataNascimento.Day > DateTime.Now.Day))
                idade--;

            return idade;
        }
    }
}