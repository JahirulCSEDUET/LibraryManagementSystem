using LibraryManagementSystem.Business.Modulos;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Presentation.Modules.Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Presentation.Modules.Books
{
    public class BooksViewModelProvider : IBooksViewModelProvider
    {
        private readonly IBookService _bookService;

        public BooksViewModelProvider(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Book> AddAsync(BookCreateVM book)
        {
            var books = new Book
            {
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear =book.PublicationYear,
                AddedDate = DateTime.UtcNow,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                Pages = book.Pages,
                LastUpdated = DateTime.UtcNow,
            };
            await _bookService.AddAsync(books);
            return books;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book != null) {
                return false;
            }
            return await _bookService.DeleteAsync(book);
        }

        public async Task<IEnumerable<BookListVM>> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();
            if (books != null)
            {
                return null;
            }
            var bookVM = books.Select(b => new BookListVM
            {
                Id = b.Id,
                Title = b.Title,
                IsAvailable=b.IsAvailable,
                ISBN=b.ISBN,
                Pages=b.Pages,
                LastUpdated = b.LastUpdated,
                PublicationYear=b.PublicationYear,
                AddedDate=b.AddedDate,
                Genre = b.Genre
            }).ToList();
            return bookVM;
        }

        public async Task<BookEditVM?> GetByIdAsync(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            
            var books = new BookEditVM
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                Pages = book.Pages,
                LastUpdated = book.LastUpdated
            };
            return books;
        }

        public async Task<IReadOnlyList<BookListVM>> SearchAsync(BookFilterVM bookFilterVM)
        {
            var book = await _bookService.SearchAsync(bookFilterVM.Title, bookFilterVM.ISBN, bookFilterVM.Genre);
            var bookvm = book.Select(b => new BookListVM
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublicationYear = b.PublicationYear,
                AddedDate = b.AddedDate,
                Genre = b.Genre,
                IsAvailable = b.IsAvailable,
                Pages = b.Pages,
                LastUpdated = b.LastUpdated
            }).ToList();
            return bookvm; 
        }

        public async Task UpdateAsync(BookEditVM bookVM)
        {
            var book = new Book();
            book.Id = bookVM.Id;
            book.Title = bookVM.Title;
            book.ISBN = bookVM.ISBN;
            book.LastUpdated = DateTime.UtcNow;
            book.Genre = bookVM.Genre;
            book.IsAvailable = bookVM.IsAvailable;
            book.Pages = bookVM.Pages;
            book.PublicationYear = bookVM.PublicationYear;
            await _bookService.UpdateAsync(book);

        }
    }
}
