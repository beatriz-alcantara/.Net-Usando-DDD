using Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Model;
using Domain.Validators;
using FluentValidation;
using System.Linq;

namespace Service
{
    public class LojaService
    {
        private LojaRepository repository;
        private LojaValidator lojaValidator;
        public LojaService(LojaRepository repo)
        {
            repository = repo;
            lojaValidator = new LojaValidator();
        }

        public List<Loja> ListarTodos()
        {
            return repository.ListarTodos();
        }

        public Loja ObterUm(int id)
        {
            return repository.ObterUm(id);
        }

        public string CadastrarLoja(Loja loja)
        {
            try
            {
                lojaValidator.ValidateAndThrow(loja);
                repository.Salvar(loja);
                return "Loja cadastrada com sucesso";
            } catch (ValidationException er)
            {
                return er.Message;
            }
        }

        public string Atualizar (Loja loja)
        {
            try
            {
                lojaValidator.ValidateAndThrow(loja);
                repository.Atualizar(loja);
                return "Loja atualizada com sucesso";
            } catch (ValidationException er)
            {
                return er.Message;
            }
        }

        public List<Cliente> ListarClientes(int lojaId)
        {
            return repository.ListarClientes(lojaId);
        }
    }
}
