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
        [Route("listagem-relacionamento")]
        [HttpGet]
        public IActionResult ListagemRelacionamento() {
            return Ok(repository.ListagemRelacionamentoLoja());
        }
    }
}