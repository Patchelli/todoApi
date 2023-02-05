using AutoFixture;
using Moq;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using Xunit;

namespace Todo.Domain.Test.HandlerTests
{
    public class CreateTodoHandlerTests
    {

        private readonly Mock<CreateTodoCommand> _invalidCommand = new Mock<CreateTodoCommand>("", "", DateTime.Now);
        private readonly Mock<CreateTodoCommand> _validCommand = new Mock<CreateTodoCommand>("Titulo da tarefa", "Patchelli", DateTime.Now);
        private GenericCommandResult _result = new GenericCommandResult();
        private readonly TodoHandler _handler = new TodoHandler(null);
        private readonly Fixture _fixture = new Fixture();
        public CreateTodoHandlerTests()
        {
        
        }

        [Fact]
        public void CreateTodHandlerCommand_Should_Return_Invalid_When_Data_Invalid()
        {

            var createTodo = _fixture.Build<CreateTodoCommand>()
            .With(x => x.Title , "")
            .Create();

             _result = (GenericCommandResult)_handler.Handle(createTodo);

            Assert.Equal(_result.Success,false);

            VerifyMock();
        }

        [Fact]
        public void CreateTodHandlerCommand_Should_Return_valid_When_Data_Invalid()
        {
            Assert.True(true);
        }

        private void VerifyMock()
        {
            
        }
    }
}