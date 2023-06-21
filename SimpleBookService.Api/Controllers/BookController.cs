using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleBookService.Web.Models.Dtos;
using SimpleBookService.Web.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleBookService.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetAll());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _bookService.GetById(id));
        }

        // POST api/<BookController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _bookService.Add(book));
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Put(int id, [FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(await _bookService.Update(bookDto));
        }
    }
}


