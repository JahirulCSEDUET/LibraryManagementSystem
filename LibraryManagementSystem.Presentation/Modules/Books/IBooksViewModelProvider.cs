using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Presentation.Modules.Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Presentation.Modules.Books
{
    public interface IBooksViewModelProvider
    {
        Task<BookEditVM?> GetByIdAsync(int id);
        Task<IEnumerable<BookListVM>> GetAllAsync();
        Task<IReadOnlyList<BookListVM>> SearchAsync(BookFilterVM bookFilterVM);
        Task<Book> AddAsync(BookCreateVM book);
        Task UpdateAsync(BookEditVM bookVM);
        Task<bool> DeleteAsync(int id);
    }
}
