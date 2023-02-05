using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>
    // IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Ops! parece que sua tarefa está errada",
                    command.Notifications
                );
            //  Gerar o TodoItem

            var todo = new TodoItem(command.Title, command.Date, command.User);

            //  Salvar no banco
            _repository.Create(todo);

            // Retornar o resultado

            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }
    }
}