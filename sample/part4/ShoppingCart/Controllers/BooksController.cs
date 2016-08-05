using AutoMapper;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService = new BookService();
        MapperConfiguration config;
        IMapper mapper;

        public BooksController()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<Author, AuthorViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
            });
            mapper = config.CreateMapper();
        }

        // GET: Books
        public ActionResult Index(int categoryId)
        {
            var books = _bookService.GetByCategoryId(categoryId);

            ViewBag.SelectedCategoryId = categoryId;

            return View(
                mapper.Map<List<Book>, List<BookViewModel>>(books)
            );
        }

        public ActionResult Details(int id)
        {
            var book = _bookService.GetById(id);

            return View(
               mapper.Map<Book, BookViewModel>(book)
            );
        }

        [ChildActionOnly]
        public PartialViewResult Featured()
        {
            var books = _bookService.GetFeatured();

            return PartialView(
               mapper.Map<List<Book>, List<BookViewModel>>(books)
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}