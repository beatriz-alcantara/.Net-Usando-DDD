using System;
using Data.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Application.Controllers {
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase {
        private readonly ClienteService service;
        public ClienteController(ClienteRepository repo)
        {
            service = new ClienteService(repo);
        }

        [HttpGet]
        public IActionResult ListarTodos() {
            return Ok(service.ListarTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterUm(int id) {
            return Ok(service.ObterUm(id));
        }
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente) {
            try {
                string resposta = service.CadastrarCliente(cliente);  
                return Ok(resposta);
            } catch (Exception e) {
                return Problem(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Atualizar (Cliente cliente) {
            return Ok(service.Atualizar(cliente));
        }
    }
}