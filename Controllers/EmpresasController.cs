using DesafioPagueVeloz.DAL;
using DesafioPagueVeloz.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPagueVeloz.Controllers
{
    [Route("api/[controller]")]
    public class EmpresasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpresasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.EmpresaRepository.GetAll());
        }

        [HttpGet("{cnpj}")]
        public IActionResult Get(string cnpj)
        {
            var empresa = _unitOfWork.EmpresaRepository.GetById(cnpj);
            if (empresa == null)
                return NotFound();

            return Ok(empresa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Empresa empresa)
        {
            var novaEmpresa = new Empresa
            {
                CNPJ = empresa.CNPJ,
                NomeFantasia = empresa.NomeFantasia,
                UF = empresa.UF
            };

            _unitOfWork.EmpresaRepository.Add(novaEmpresa);
            _unitOfWork.Save();

            return Ok(novaEmpresa);
        }
    }
}