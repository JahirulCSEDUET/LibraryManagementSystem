using LibraryManagementSystem.Infrastructure.Repositories.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IBookRepository BookRepository { get; }
    }
}
