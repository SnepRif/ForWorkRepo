using System.Collections.Generic;

namespace ArrayMvcProj.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}