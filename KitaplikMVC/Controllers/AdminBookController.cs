using AutoMapper;
using KitaplikMVC.Models.DTOs;
using KitaplikMVC_DAL;
using KitaplikMVC_DAL.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KitaplikMVC.Controllers
{
    public class AdminBookController : Controller
    {
        private readonly AdminDbContext context;
        private readonly IMapper mapper;

        public AdminBookController(AdminDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var BookList = context.Books.ToList();
            IList<BookListDto> books = mapper.Map<IList<BookListDto>>(BookList);

            return View(books);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var kitap = context.Books.FirstOrDefault(p => p.Id == id);
            BookUpdateDto updateDto = mapper.Map<BookUpdateDto>(kitap);

            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Update(BookUpdateDto input)
        {
            if (!ModelState.IsValid) return View(input);
            Book book = mapper.Map<Book>(input);

            context.Books.Update(book);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookCreateDto updateDto = new();

            return View(updateDto);
        }

        [HttpPost]
        public IActionResult Create(BookCreateDto input)
        {
            if (ModelState.IsValid)
            {
                Book book = mapper.Map<Book>(input);
                context.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(input);
        }

    }
}
