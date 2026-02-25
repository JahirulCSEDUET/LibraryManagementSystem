using LibraryManagementSystem.Business.Exceptions;
using LibraryManagementSystem.Infrastructure.Repositories.Books;
using LibraryManagementSystem.Presentation.Modules.Books;
using LibraryManagementSystem.Presentation.Modules.Books.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksViewModelProvider _bookViewModelProvider;

        public BookController(IBooksViewModelProvider bookViewModelProvider)
        {
            _bookViewModelProvider = bookViewModelProvider;
        }

        public async Task<IActionResult> Index(BookFilterVM bookFilter)
        {
            var books = await _bookViewModelProvider.SearchAsync(bookFilter);
            
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateVM bookCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookCreateVM);
            }
            try
            {
                await _bookViewModelProvider.AddAsync(bookCreateVM);
                TempData["SuccessMessage"] = "The book was successfully added.";
                return RedirectToAction(nameof(Index));
            }
            catch (DuplicateIsbnException ex)
            {
                ModelState.AddModelError(nameof(BookCreateVM.ISBN), ex.Message);
                return View(bookCreateVM);
            }
            
        }
        public async Task<IActionResult> Edit(int id) {
            try
            {
                var book = await _bookViewModelProvider.GetByIdAsync(id);
                return View(book);
            }
            catch(BookNotFoundException )
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookEditVM bookEditVM) {
            if (!ModelState.IsValid) {
                return View(bookEditVM);
            }
            try
            {
                await _bookViewModelProvider.UpdateAsync(bookEditVM);
                TempData["SuccessMessage"] = "The book was successfully edited.";
                return RedirectToAction(nameof(Index));
            }
            catch (DuplicateIsbnException ex)
            {
                ModelState.AddModelError(nameof(BookEditVM.ISBN), ex.Message);
                return View(bookEditVM);
            }
            catch (InvalidPublicationYearException ex)
            {
                ModelState.AddModelError(nameof(BookListVM.PublicationYear), ex.Message);
                return View(bookEditVM);
            }
            catch (BookNotFoundException )
            {
                return NotFound();
            }            
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var book = await _bookViewModelProvider.GetByIdAsync(id);
                return View(book);
            }
            catch(BookNotFoundException )
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _bookViewModelProvider.GetByIdAsync(id);
                return View(book);
            }
            catch (BookNotFoundException )
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var res = await _bookViewModelProvider.DeleteAsync(id);
                TempData["SuccessMessage"] = "The book was successfully removed from the library catalog.";
                return RedirectToAction(nameof(Index));
            }
            catch (BookNotFoundException )
            {
                return NotFound();
            }
        }
    }
}
