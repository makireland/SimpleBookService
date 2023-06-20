namespace SimpleBookService.Web.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Registration { get; set; }
        public string Description { get; set; }
        public virtual List<Category> Categories { get; set; }

        public Book()
        {
            Categories = new List<Category>();
        }
    }
}
