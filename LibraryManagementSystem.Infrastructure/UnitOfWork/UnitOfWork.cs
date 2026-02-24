using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Repositories.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryManagementSystemDbContext _context;

        public UnitOfWork(LibraryManagementSystemDbContext context, IBookRepository bookRepository)
        {
            _context = context;
            BookRepository = bookRepository;
        }

        public IBookRepository BookRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
