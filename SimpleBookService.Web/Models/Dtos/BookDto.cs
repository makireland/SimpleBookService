namespace SimpleBookService.Web.Models.Dtos

{
    public class BookDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Registration { get; set; }
        public string Description { get; set; }
        public virtual CategoryDto CategoryDto { get; set; }

    }
}
