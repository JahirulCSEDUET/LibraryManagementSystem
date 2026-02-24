using LibraryManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementSystem.Presentation.Modules.Books.ViewModels
{
    public class BookEditVM
    {
        public int Id { get; set; } 
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Title must be between 3 to 150 character!")]
        public string Title { get; set; }
        [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN must be between 10 to 13 character!")]
        public string ISBN { get; set; }

        [Range(1500, 2030, ErrorMessage = "Publucation year must be between 1500 and 2023!")]
        public int PublicationYear { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Pages must be greater than 0")]
        public int Pages { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
