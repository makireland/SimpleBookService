namespace SimpleBookService.Web.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            Books = new HashSet<Book>();
        }
    }
}
