using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.Product_Info.Count() == 0)
            {
                _context.Product_Info.Add(new TodoItem { ProductName = "Item1" });
                _context.SaveChanges();
            }
        } 

                    [HttpGet]
            public async Task<List<TodoItem>> GetAll()
            {
                return await _context.Product_Info.ToListAsync();
            }

           /* [HttpGet("{id}", Name = "GetTodo")]
            public IActionResult GetById(int id)
            {
                var item = _context.Product_Info.FirstOrDefault(t => t.ProductId == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }  */

            [HttpPost]
            public IActionResult Create([FromBody] TodoItem item)
            {
                if (item == null)
                {
                    return BadRequest();
                }

                _context.Product_Info.Add(item);
                _context.SaveChanges();

                return CreatedAtRoute("GetTodo", new { id = item.ProductId }, item);
            } 

            [HttpPut("{id}")]
                public IActionResult Update(int id, [FromBody] TodoItem item)
                {
                    if (item == null || item.ProductId != id)
                    {
                        return BadRequest();
                    }

                    var todo = _context.Product_Info.FirstOrDefault(t => t.ProductId == id);
                    if (todo == null)
                    {
                        return NotFound();
                    }


                    todo.ProductName = item.ProductName;
                    todo.ProductDescription = item.ProductDescription;

                    _context.Product_Info.Update(todo);
                    _context.SaveChanges();
                    return new NoContentResult();
                } 

                [HttpDelete("{id}")]
                public IActionResult Delete(int id)
                {
                    var todo = _context.Product_Info.FirstOrDefault(t => t.ProductId == id);
                    if (todo == null)
                    {
                        return NotFound();
                    }

                    _context.Product_Info.Remove(todo);
                    _context.SaveChanges();
                    return new NoContentResult();
                } 
    }
}