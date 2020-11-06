using AutoMapper;
using Data;
using Data.Repository;
using Domain.Map;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;

namespace Application.Controllers {
    [Route("api/v1/loja")]
    [ApiController]
    public class LojaController : ControllerBase {
        private readonly LojaService lojaService;
        private readonly IMapper mapper;
        public LojaController(LojaRepository rp, IMapper _mapper)
        {
            lojaService = new LojaService(rp);
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult ListarTodos() {
            var result = mapper.Map<List<Loja>, List<LojaMapper>>(lojaService.ListarTodos());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult ObterUm(int id) {
            var result = mapper.Map<Loja, LojaMapper>(lojaService.ObterUm(id));
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CadastrarLoja(Loja loja) {
            return Ok(lojaService.CadastrarLoja(loja));
        }
        [HttpPut]
        public IActionResult Atualizar(Loja loja) {
            return Ok(lojaService.Atualizar(loja));
        }
        [HttpGet("clientes/{lojaId}")]
        public IActionResult ListarClientes(int lojaId)
        {
            var result = mapper.Map<List<Cliente>, List<ClienteMapper>>(lojaService.ListarClientes(lojaId));
            return Ok(result);
        }
    }
}