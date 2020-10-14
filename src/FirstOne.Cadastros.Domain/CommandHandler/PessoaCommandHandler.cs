﻿using FirstOne.Cadastros.Domain.Command;
using FirstOne.Cadastros.Domain.Entities;
using FirstOne.Cadastros.Domain.Interfaces;
using FirstOne.Cadastros.Domain.Mediator;
using FirstOne.Cadastros.Domain.Messaging;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FirstOne.Cadastros.Domain.CommandHandler
{
    public class PessoaCommandHandler :
        IRequestHandler<AdicionarPessoaCommand, bool>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public PessoaCommandHandler(IPessoaRepository pessoaRepository,
                                    IMediatorHandler mediatorHandler)
        {
            _pessoaRepository = pessoaRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AdicionarPessoaCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                {
                    await _mediatorHandler.PublicarDomainNotification(new DomainNotification(error.ErrorMessage));
                }
                return false;
            }
                       
            var pessoa = new Pessoa(Guid.NewGuid(), request.Nome);
            _pessoaRepository.Adicionar(pessoa);

            return true;
        }
    }
}