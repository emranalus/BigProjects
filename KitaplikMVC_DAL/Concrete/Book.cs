using KitaplikMVC_DAL.Abstract;

namespace KitaplikMVC_DAL.Concrete
{

    public enum Genre
    {
        Science_Fiction,
        Horror,
        Romance,
        Self_Help,
        History,
        Religion,
        Psychology,
        Economy,
        Philosohpy
    }

    public class Book : BaseEntity
    {

        // What does a book have?
        // A book has a Author - Check!
        // A book has a Price  - Check!
        // A book has a Title  - Check!
        // A book has a Genre  - Check!

        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }

    }
}
