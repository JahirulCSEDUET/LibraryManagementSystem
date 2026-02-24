using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Presentation.Modules.Books.ViewModels
{
    public class BookListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
