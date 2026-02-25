using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Repositories.Books
{
    public class BookRepository:Repository<Book>,IBookRepository
    {
        private readonly LibraryManagementSystemDbContext _context;
        public BookRepository(LibraryManagementSystemDbContext context):base(context) {
            _context = context;
        }

        public async Task<bool> ExistByISBN(string isbn, int? excludedId = null)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                return false;
            }
            var query= _context.Books.AsNoTracking().Where(b => b.ISBN.Trim().ToLower() == isbn.Trim().ToLower());
            if (excludedId.HasValue)
            {
                query = query.Where(c => c.Id != excludedId.Value);
            }
            return await query.AnyAsync();
        }

    }
}
