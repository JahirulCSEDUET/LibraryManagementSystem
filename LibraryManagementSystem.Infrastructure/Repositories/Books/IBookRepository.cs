using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Repositories.Books
{
    public interface IBookRepository:IRepository<Book>
    {
        Task<bool> IsIsbnUniqueAsync(string isbn, int? excludedId =null);
    }
}
