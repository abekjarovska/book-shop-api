﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        private ILoggerManager _logger;

        public BooksController(IRepositoryWrapper repoWrapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<IList<Books>> Get()
        {

            var books = _repoWrapper.Books.FindAll();
            return Ok(books);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Books book)
        {
            _repoWrapper.Books.Create(book);
            _logger.LogInfo("api/Books  Created book: " + book.BookId);
        }
    }
}