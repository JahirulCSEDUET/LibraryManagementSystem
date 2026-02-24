using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Business.Modulos
{
    public interface IBookService
    {
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IReadOnlyList<Book>> SearchAsync(string? searchTerm = null, Genre? genre = null);
        Task<Book> AddAsync(Book book);
        void UpdateAsunc(Book book);
        Task<bool> DeleteAsync(Book book);
    }
}
