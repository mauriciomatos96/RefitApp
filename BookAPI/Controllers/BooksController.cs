﻿using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<BookModel> books = new()
        {
            new BookModel { Id = 1, Title = "Don quijote", Description = "Un libro clasico" },
            new BookModel { Id = 2, Title = "El principito", Description = "otro libro clasico" }, 
            new BookModel { Id = 3, Title = "Harry Potter", Description = "Un buen libro" } 
        };

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<BookModel> Get()
        {
            return books;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public BookModel Get(int id)
        {
            return books.Where(b => b.Id == id).FirstOrDefault();
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] BookModel value)
        {
            books.Add(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookModel value)
        {
            books.Remove(books.Where(b => b.Id == id).FirstOrDefault());
            books.Add(value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            books.Remove(books.Where(b => b.Id == id).FirstOrDefault());
        }
    }
}
