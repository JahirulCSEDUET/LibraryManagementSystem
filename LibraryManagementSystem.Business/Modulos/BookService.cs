using LibraryManagementSystem.Business.Exceptions;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enums;
using LibraryManagementSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Business.Modulos
{

    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfwork;

        public BookService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<Book> AddAsync(Book book)
        {
            book.AddedDate = DateTime.Now;
            bool exist = await _unitOfwork.BookRepository.ExistByISBN(book.ISBN);
            if (exist) {
                throw new DuplicateIsbnException($"{book.ISBN} is already exist!!");
            }
            if(book.PublicationYear<1500 || book.PublicationYear > DateTime.Now.Year + 5)
            {
                throw new InvalidPublicationYearException($"Publication year must be beetween 1500 to {DateTime.Now.Year + 5}");
            }
            
            await _unitOfwork.BookRepository.AddAsync(book);
            await _unitOfwork.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(Book book)
        {
            _unitOfwork.BookRepository.DeleteAsync(book);
            if (book == null)
            {
                throw new BookNotFoundException("Book is not found!");
            }
            return await _unitOfwork.SaveChangesAsync()>0;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var book = await _unitOfwork.BookRepository.GetAllAsync();
            return book;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await _unitOfwork.BookRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new BookNotFoundException("Book is not found!");
            }
            return book;
        }

        public async Task<IReadOnlyList<Book>> SearchAsync(string? title = null, string? isbn=null, string? genre = null)
        {
            var books = _unitOfwork.BookRepository.Search();
            if(!string.IsNullOrWhiteSpace(title))
            {
                books = books.Where(b => b.Title.ToLower().Contains(title.ToLower()));
            }
            if(!string.IsNullOrWhiteSpace(isbn))
            {
                books = books.Where(b=> b.ISBN == isbn);
            }
            if (!string.IsNullOrWhiteSpace(genre) && Enum.TryParse(genre, out Genre enumGenre))
            {
                books = books.Where(b=> b.Genre.ToString() == genre);
            }
            return await books.ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var books = await _unitOfwork.BookRepository.GetByIdAsync(book.Id);
            if (books == null)
            {
                throw new BookNotFoundException("Book is not found!");
            }
            _unitOfwork.BookRepository.UpdateAsync(book);
            await _unitOfwork.SaveChangesAsync();
        }
    }
}
