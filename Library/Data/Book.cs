using Library.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataConstants;

namespace Library.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(BookAuthorMaxLength)] 
        public string Author { get; set; }= string.Empty;

        [Required]
        [StringLength(BookDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl {  get; set; } = string.Empty;

        [Required]
        [Range(BookRatingMinValue,BookRatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        public IList<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}
