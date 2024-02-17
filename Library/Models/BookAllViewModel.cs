﻿namespace Library.Models
{
    public class BookAllViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public string Description = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author {  get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Category { get; set; } = string.Empty;

    }
}
