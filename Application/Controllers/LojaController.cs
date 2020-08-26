using Data;
using Data.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers {
    [Route("api/v1/loja")]
    [ApiController]
    public class LojaController : ControllerBase {
        private readonly LojaRepository repository;
        public LojaController(LojaRepository rp)
        {
            repository = rp;
        }

        [HttpGet]
        public IActionResult ListarTodos() {
            return Ok(repository.ListarTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterUm(int id) {
            return Ok(repository.ObterUm(id));
        }
        [HttpPost]
        public IActionResult CadastrarLoja(Loja loja) {
            repository.Salvar(loja);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(Loja loja) {
            repository.Atualizar(loja);
            return Ok();
        }
    }
}