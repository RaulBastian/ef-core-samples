using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace manyToOneWithDelete
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        private List<Book> books = new List<Book>();
        public virtual IReadOnlyCollection<Book> Books { get { return books; } }

        public void AddBook(string bookName)
        {
           if(Books.Any(b => b.Name == bookName))
            {
                return;
            }

            var b = new Book()
            {
                Author = this,
                Name = bookName
            };

            this.books.Add(b);
        }

        
    }
}
