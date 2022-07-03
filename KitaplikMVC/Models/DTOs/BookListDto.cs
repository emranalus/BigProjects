using KitaplikMVC_DAL.Abstract;
using KitaplikMVC_DAL.Concrete;

namespace KitaplikMVC.Models.DTOs
{
    public class BookListDto
    {

        public int Id { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public State State { get; set; }

    }
}
