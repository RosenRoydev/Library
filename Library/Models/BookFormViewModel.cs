using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants;

namespace Library.Models
{
    public class BookFormViewModel
    {


        [Required(ErrorMessage = RequiredField)]
        [StringLength(BookTitleMaxLength
            , MinimumLength = BookTitleMinLength
            , ErrorMessage = RequiredLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(BookAuthorMaxLength
            , MinimumLength = BookAuthorMinLength
            , ErrorMessage = RequiredLength)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(BookDescriptionMaxLength
            ,MinimumLength = BookDescriptionMinLength
            ,ErrorMessage = RequiredLength) ]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredField)]
        public string Url { get; set; } = string.Empty;

        [Required]
        [Range(BookRatingMinValue, BookRatingMaxValue,ErrorMessage = RatingRange)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryTypesViewModel> Categories { get; set; } = new List<CategoryTypesViewModel>();
    }
}
