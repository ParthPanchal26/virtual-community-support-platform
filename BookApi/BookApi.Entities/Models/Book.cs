using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Entities.Models {
    public class Book {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; } = string.Empty;
        [Required]
        public string BookDescription { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
    }
}
