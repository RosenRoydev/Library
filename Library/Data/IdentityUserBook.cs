using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
    public class IdentityUserBook
    {
        [Required]
        [ForeignKey(nameof(CollectorId))]
        public string CollectorId {  get; set; } = string.Empty;

        public IdentityUser Collector { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }

        public Book Book { get; set; }= null!;
    }
}
//• CollectorId – a string, Primary Key, foreign key (required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key (required)
//• Book – Book