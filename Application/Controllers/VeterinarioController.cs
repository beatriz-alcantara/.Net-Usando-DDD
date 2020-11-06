using Data.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("/veterinario")]
    public class VeterinarioController : ControllerBase
    {
        private readonly VeterinarioService veterinarioService;
        public VeterinarioController(VeterinarioRepository repo)
        {
            veterinarioService = new VeterinarioService(repo);
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(veterinarioService.ListarTodos());
        }
        [HttpGet("{id}")]
        public IActionResult ObterUm(int id)
        {
            return Ok(veterinarioService.ObterUm(id));
        }
        [HttpPost]
        public IActionResult Salvar(Veterinario veterinario)
        {
            return Ok(veterinarioService.Salvar(veterinario));
        }
        [HttpPut]
        public IActionResult Atualizar(Veterinario veterinario)
        {
            if (veterinario.Id > 0)
            {
                return Ok(veterinarioService.Atualizar(veterinario));
            } else
            {
                return BadRequest("Informe o Id");
            }
            
        }
    }
}
