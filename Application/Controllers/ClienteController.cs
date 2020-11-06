using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data.Repository;
using Domain.Enums;
using Domain.Map;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Application.Controllers {
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase {
        private readonly ClienteService service;
        private readonly IMapper mapper;
        public ClienteController(ClienteRepository repo, IMapper _mapper)
        {
            service = new ClienteService(repo);
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult ListarTodos() {
            var result = mapper.Map<List<Cliente>, List<ClienteMapper>>(service.ListarTodos());
            return Ok(result);
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
        [HttpGet("pets/{idCliente}")]
        public IActionResult ListarPets(int idCliente)
        {
            var result = mapper.Map<List<Pet>, List<PetMapper>>(service.ListarPets(idCliente));
            return Ok(result);
        }
    }
}