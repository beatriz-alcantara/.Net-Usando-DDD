using System;
using Data.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers {
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase {
        private readonly ClienteRepository repository;
        public ClienteController(ClienteRepository repo)
        {
            repository = repo;
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
        public IActionResult CadastrarCliente(Cliente cliente) {
            try {
                cliente.DataNascimento = Convert.ToDateTime(cliente.DataNascimento);
                repository.Salvar(cliente);
                return Ok();
            } catch (Exception e) {
                return BadRequest(e.Source);
            }
            
        }
        [HttpPut]
        public IActionResult Atualizar (Cliente cliente) {
            repository.Atualizar(cliente);
            return Ok("Cliente atualizado com sucesso");
        }
    }
}