using Data.Repository;
using Domain.Model;
using Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    class PetService
    {
        private readonly PetValidator validator;
        private readonly PetRepository repository;

        public PetService(PetRepository repo)
        {
            repository = repo;
        }

        public List<Pet> ListarTodos()
        {
            return repository.ListarTodos();
        }

        public string CadastrarPet(Pet pet)
        {
            try
            {
                validator.ValidateAndThrow(pet);
                repository.Salvar(pet);
                return "Pet Cadastrado com sucesso";
            }
            catch(ValidationException er)
            {
                return er.Message;
            }
        }
        
        public string Atualizar(Pet pet)
        {
            try
            {
                validator.ValidateAndThrow(pet);
                repository.Atualizar(pet);
                return "Pet atualizado com sucesso";
            }
            catch (ValidationException er)
            {
                return er.Message;
            }
        }

        public Pet ObterUm(int id)
        {
            return repository.ObterUm(id);
        }

    }
}
