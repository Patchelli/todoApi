using AutoFixture;
using Moq;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Xunit;

namespace Todo.Domain.Test.QueriesTests
{
    public class TodoQueryTests
    {
        private Fixture _fixture = new Fixture();
        private Mock<ITodoRepository> _repository = new Mock<ITodoRepository>();

        [Fact]
        public void GetAll_Should_Return_TodoItem_When_User_only()
        {
            var listItens = _fixture.Build<TodoItem>()
                            .CreateMany(5)
                            .ToList();

            var item1 = _fixture.Build<TodoItem>()
            .With(x => x.Title, "Lavar Roupa")
            .With(x => x.User, "Patchelli")
            .Create();

            listItens.Add(item1);

            var result = listItens.AsQueryable().Where(TodoQueries.GetAll("Patchelli"));

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void GetAllDone_Should_Return_TodoItem_When_Done()
        {
            var listItens = _fixture.Build<TodoItem>()
                            .CreateMany(2)
                            .ToList();

            var item1 = _fixture.Build<TodoItem>()
            .With(x => x.Title, "Lavar Roupa")
            .With(x => x.Done,true)
            .With(x => x.User, "Patchelli")
            .Create();

            listItens.Add(item1);

            var result = listItens.AsQueryable().Where(TodoQueries.GetAllDone("Patchelli"));

            Assert.Equal(1, result.Count());
        }
    }
}