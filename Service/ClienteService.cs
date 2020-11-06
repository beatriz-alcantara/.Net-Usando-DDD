using System;
using System.Collections.Generic;
using Data.Repository;
using Domain.Model;
using Domain.ResultValidations;
using Domain.Validators;
using FluentValidation;

namespace Service
{
    public class ClienteService
    {
        private readonly ClienteRepository repository;
        private readonly ClienteValidator validator;
        public ClienteService(ClienteRepository repo)
        {
            repository = repo;
            validator = new ClienteValidator();
        }

        public List<Cliente> ListarTodos() {
            return repository.ListarTodos();
        }
        public Cliente ObterUm(int id) {
            return repository.ObterUm(id);
        }
        public string CadastrarCliente(Cliente cliente) {
            try {
                validator.ValidateAndThrow(cliente);
                repository.Salvar(cliente);
                return "Cliente salvo com sucesso";
            } catch (ValidationException er) {
                return er.Message;
            }
        }
        public string Atualizar (Cliente cliente) {
            try
            {
                validator.ValidateAndThrow(cliente);
                repository.Atualizar(cliente);
                return "Cliente atualizado com sucesso";
            } catch (ValidationException er)
            {
                return er.Message;
            }
        }
        public List<Pet> ListarPets(int idCliente)
        {
            return repository.ListarPets(idCliente);
        }
    }
}
