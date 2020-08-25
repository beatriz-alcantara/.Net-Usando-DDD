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
            return Ok(repository.ListarTodos().Result);
        }
        [HttpPost]
        public IActionResult CadastrarLoja(Loja loja) {
            repository.Salvar(loja);
            return Ok();
        }
    }
}