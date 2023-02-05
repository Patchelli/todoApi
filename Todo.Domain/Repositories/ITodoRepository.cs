using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        void Delete(TodoItem todo);
        TodoItem GetById(Guid Id, string user);

        IEnumerable<TodoItem> GetAll(string user);
        IEnumerable<TodoItem> GetAllDone(string user);
        IEnumerable<TodoItem> GetAllUnDone(string user);
        IEnumerable<TodoItem> GetByPeriod(string user,DateTime date, bool done);
    }
}