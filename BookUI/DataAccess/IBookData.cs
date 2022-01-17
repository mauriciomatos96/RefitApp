using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookUI.Models;
using Refit;

namespace BookUI.DataAccess
{
    public interface IBookData
    {
        [Get(path:"/Books")]
        Task<List<BookModel>> GetBooks();

        [Get(path:"/Books/{id}")]
        Task<BookModel> GetBook(int id);

        [Post(path:"/Books")]
        Task CreateBook([Body] BookModel book);

        [Put(path:"/Books/{id}")]
        Task UpdateBook(int id, [Body] BookModel book);

        [Delete(path: "/Books/{id}")]
        Task DeleteBook(int id);
    }
}
