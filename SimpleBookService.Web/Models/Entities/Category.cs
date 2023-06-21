namespace SimpleBookService.Web.Models.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            Books = new HashSet<Book>();
        }
    }
}
