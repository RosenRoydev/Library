namespace Library.Data
{
    public static class DataConstants
    {
        public const int BookTitleMinLength = 10;
        public const int BookTitleMaxLength = 50;

        public const int BookAuthorMinLength = 5;
        public const int BookAuthorMaxLength = 50;

        public const int BookDescriptionMinLength = 5;
        public const int BookDescriptionMaxLength = 5000;

        public const double BookRatingMinValue = 0;
        public const double BookRatingMaxValue = 10;

        public const int BookCategoryMinValue = 5;
        public const int BookCategoryMaxValue = 50;

        public const string RequiredField = "The field {0} is required!";
        public const string RequiredLength = "The field {0} must be between {2} and {1} characters";
        public const string RatingRange = "The range must be between 0.00 and 10.00 include";
    }
}
