using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Library.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Data.DataConstants.BookCategoryMaxValue)]
        public string Name { get; set; }= string.Empty;

        public IList<Book> Books { get; set; }= new List<Book>(); 
    }
}

//• Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 5 and max length 50 (required)
//• Has Books – a collection of type Books