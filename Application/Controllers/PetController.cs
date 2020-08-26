using Data.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers {
    [ApiController]
    [Route("api/v1/pet")]
    public class PetController : ControllerBase {
        private readonly PetRepository repository;
        public PetController(PetRepository repo)
        {
            repository = repo;
        }
        
        [HttpGet]
        public IActionResult Listar () {
            return Ok(repository.ListarTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterUm (int id) {
            repository.ObterUm(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult Salvar (Pet pet) {
            repository.Salvar(pet);
            return Ok("Pet cadastrado com sucesso");
        }
        [HttpPut]
        public IActionResult Atualizar (Pet pet) {
            repository.Atualizar(pet);
            return Ok("Pet Atualizado");
        }
    }
}