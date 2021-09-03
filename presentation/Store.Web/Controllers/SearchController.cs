﻿using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService _bookService;

        public SearchController(BookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index(string? query)
        {
            var books = _bookService.GetAllByQuery(query);
            return View(books);
        }
    }
}
