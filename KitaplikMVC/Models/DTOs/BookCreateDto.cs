using KitaplikMVC_DAL.Concrete;
using System.ComponentModel.DataAnnotations;

namespace KitaplikMVC.Models.DTOs
{
    public class BookCreateDto
    {

        public int Id { get; set; }
        private DateTime _createDate = DateTime.UtcNow;

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        [Required(ErrorMessage = "Yazar Adı Alanı Mecburidir!")]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Fiyat Alanı Mecburidir!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Kitap Adı Alanı Mecburidir!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Kitap Türü Alanı Mecburidir!")]
        public Genre Genre { get; set; }

    }
}
