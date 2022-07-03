using AutoMapper;
using KitaplikMVC.Models.DTOs;
using KitaplikMVC_DAL.Concrete;

namespace KitaplikMVC.AutoMapper
{
    public class DbKitalikMVCProfile : Profile
    {
        public DbKitalikMVCProfile()
        {
            CreateMap<Book, BookListDto>();

            CreateMap<Book, BookUpdateDto>();
            CreateMap<BookUpdateDto, Book>();

            CreateMap<Book, BookCreateDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}
