using Data;
using Data.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Application.Controllers {
    [Route("api/v1/loja")]
    [ApiController]
    public class LojaController : ControllerBase {
        private readonly LojaService lojaService;
        public LojaController(LojaRepository rp)
        {
            lojaService = new LojaService(rp);
        }

        [HttpGet]
        public IActionResult ListarTodos() {
            return Ok(lojaService.ListarTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterUm(int id) {
            return Ok(lojaService.ObterUm(id));
        }
        [HttpPost]
        public IActionResult CadastrarLoja(Loja loja) {
            return Ok(lojaService.CadastrarLoja(loja));
        }
        [HttpPut]
        public IActionResult Atualizar(Loja loja) {
            return Ok(lojaService.Atualizar(loja));
        }
    }
}