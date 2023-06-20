namespace SimpleBookService.Web.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

        public Category()
        {
            Books = new List<Book>();
        }
    }
}
