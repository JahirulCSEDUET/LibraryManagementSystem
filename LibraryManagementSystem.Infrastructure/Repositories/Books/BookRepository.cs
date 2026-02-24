using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Repositories.Books
{
    public class BookRepository:Repository<Book>,IBookRepository
    {
        public BookRepository(LibraryManagementSystemDbContext context):base(context) { }
    }
}
