using System;
using System.Collections.Generic;
using System.Linq;

namespace netcore_webapi_controller_api.Models
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ISet<Todo> todos = new HashSet<Todo>();

        public TodoRepository()
        {
            todos.Add(new Todo(1, "name", false, 1));
            todos.Add(new Todo(2, "name2", false, 2));
        }

        public Todo findById(long id)
        {
            return todos.ToList().FirstOrDefault(todo => todo.Id == id);
        }

        public List<Todo> GetAll()
        {
            return todos.ToList();
        }

        public void add(Todo todo)
        {
            if (todo.Id == 0)
            {
                todo.Id = todos.Count + 1;
                todo.Order = 1;
            }
            todos.Add(todo);
        }

        public void delete(Todo todo)
        {
            todos.Remove(todo);
        }
    }
}
