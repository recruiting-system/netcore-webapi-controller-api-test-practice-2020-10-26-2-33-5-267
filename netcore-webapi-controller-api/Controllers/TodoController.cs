using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore_webapi_controller_api.Controllers.Dtos;
using netcore_webapi_controller_api.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcore_webapi_controller_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAll()
        {
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodo(long id)
        {
            Todo todoOptional = _todoRepository.findById(id);

            if (todoOptional == null)
            {
                return NotFound();
            }

            return todoOptional;
        }

        [HttpPost]
        public ActionResult<Todo> SaveTodo(Todo todo)
        {
            todo.Id = _todoRepository.GetAll().Count + 1;

            _todoRepository.add(todo);

            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }

        [HttpDelete("{id}")]
        public ActionResult<Todo> DeleteTodo(long id)
        {
            Todo todoOptional = _todoRepository.findById(id);

            if (todoOptional != null)
            {
                _todoRepository.delete(todoOptional);
                return Ok();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<Todo> UpdateTodo(long id, Todo newTodo)
        {
            Todo todoOptional = _todoRepository.findById(id);

            if (todoOptional == null)
            {
                return NotFound();
            } else if (newTodo == null)
            {
                return BadRequest();
            }

            _todoRepository.delete(todoOptional);
            Todo mergedTodo = todoOptional.merge(newTodo);
            _todoRepository.add(mergedTodo);

            return Ok(mergedTodo);       
        }

    }
}
