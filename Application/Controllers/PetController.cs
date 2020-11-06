using AutoMapper;
using Data.Repository;
using Domain.Map;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.Controllers {
    [ApiController]
    [Route("api/v1/pet")]
    public class PetController : ControllerBase {
        private readonly PetRepository repository;
        private readonly IMapper mapper;
        public PetController(PetRepository repo, IMapper _mapper)
        {
            repository = repo;
            mapper = _mapper;
        }
        
        [HttpGet]
        public IActionResult Listar () {
            var result = mapper.Map<List<Pet>, List<PetMapper>>(repository.ListarTodos());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult ObterUm (int id) {
            var result = mapper.Map<Pet, PetMapper>(repository.ObterUm(id));
            return Ok(result);
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