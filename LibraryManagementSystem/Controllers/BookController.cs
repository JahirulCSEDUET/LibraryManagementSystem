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
            await _bookViewModelProvider.AddAsync(bookCreateVM);
            return RedirectToAction(nameof(Index));
            
        }
        public async Task<IActionResult> Edit(int id) {
            var book = await _bookViewModelProvider.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookEditVM bookEditVM) {
            if (!ModelState.IsValid) { 
                return View(bookEditVM);
            }
            await _bookViewModelProvider.UpdateAsync(bookEditVM);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookViewModelProvider.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookViewModelProvider.GetByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = await _bookViewModelProvider.DeleteAsync(id);
            if (!res)
            { 
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
