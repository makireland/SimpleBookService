using Microsoft.AspNetCore.Mvc;
using SimpleBookService.Web.Models.Dtos;
using SimpleBookService.Web.Services.Interfaces;

namespace SimpleBookService.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categoryService.GetAll());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        // POST api/<CategoryController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _categoryService.Add(categoryDto));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _categoryService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(await _categoryService.Update(categoryDto));
        }
    }
}
