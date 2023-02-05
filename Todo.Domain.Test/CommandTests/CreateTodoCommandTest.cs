using System;
using Todo.Domain.Commands;
using Xunit;

namespace Todo.Domain.Test.CommandTests
{
    public class CreateTodoCommandTest
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da tarefa", "Patchelli", DateTime.Now);

        public CreateTodoCommandTest()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [Fact]
        public void CreateTodoCommand_Should_Return_Invalid_When_Data_Invalid()
        {
            Assert.Equal(_invalidCommand.Valid, false);
        }

        [Fact]
        public void CreateTodoCommand_Should_Return_Valid_When_Data_Invalid()
        {
            Assert.Equal(_validCommand.Valid, true);
        }
    }
}