using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class TodoItemsController : ControllerBase
    {
        private readonly TodoListContext _context;

        public TodoItemsController(TodoListContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            
            if(todoItem==null)
            {
                return NotFound();
            }
            return todoItem;
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if(id != todoItem.Id)
            {
                return BadRequest();
            }
            _context.Entry(todoItem).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if(!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            
        }





        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id}, todoItem);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTodoItem(int id)
        {
            var todoItem= await _context.TodoItems.FindAsync(id);
            if(todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            
        }

        private bool TodoItemExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }

    }

}



