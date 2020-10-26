using System;
using System.Collections.Generic;

namespace netcore_webapi_controller_api.Models
{
    public interface ITodoRepository
    {
        public List<Todo> GetAll();
        Todo findById(long id);
        void add(Todo todo);
        void delete(Todo todoOptional);
    }
}
