using Data.Repository;
using Domain.Model;
using Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class VeterinarioService
    {
        private readonly VeterinarioRepository repository;
        private readonly VeterinarioValidator validator;
        public VeterinarioService(VeterinarioRepository repo)
        {
            repository = repo;
            validator = new VeterinarioValidator();
        }

        public List<Veterinario> ListarTodos()
        {
            return repository.ListarTodos();
        }

        public Veterinario ObterUm(int id)
        {
            return repository.ObterUm(id);
        }

        public string Salvar(Veterinario veterinario)
        {
            try
            {
                validator.ValidateAndThrow(veterinario);
                repository.Salvar(veterinario);
                return "Veterinário cadastrado com sucesso";
            } catch (ValidationException er)
            {
                return er.Message;
            }
            
        }

        public string Atualizar(Veterinario veterinario)
        {
            try
            {
                validator.ValidateAndThrow(veterinario);
                repository.Atualizar(veterinario);
                return "Veterinário atualizado com sucesso";
            } catch (ValidationException er)
            {
                return er.Message;
            }
            
        }
    }
}
