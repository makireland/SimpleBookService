using SimpleBookService.Web.Models.Dtos;

namespace SimpleBookService.Web.Models.Entities
{
    public class Book: Entity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Registration { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
    }
}
