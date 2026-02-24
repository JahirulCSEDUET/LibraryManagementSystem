using LibraryManagementSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace LibraryManagementSystem.Domain.Entities
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength =3)]
        public string Title { get; set; }
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }
        [Range(1500, 2030)]
        public int PublicationYear { get; set; }
        [Range(1, int.MaxValue)]
        public int Pages{ get; set; }

        public Genre Genre {  get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime AddedDate {  get; set; } = DateTime.UtcNow;

        public DateTime? LastUpdated { get; set; }
    }
}
