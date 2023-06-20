namespace SimpleBookService.Web.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BookDto> BooksDto { get; set; }

        public CategoryDto()
        {
            BooksDto = new HashSet<BookDto>();
        }
    }
}
