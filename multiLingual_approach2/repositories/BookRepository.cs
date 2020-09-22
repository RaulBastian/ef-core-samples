using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace multiLingual_approach2.repositories
{
    public class BookRepository
    {
        private readonly MultiDbContext context;

        public BookRepository(MultiDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Book.Where(l => l.Language.Id == 1);
        }

        public void Add(Book book)
        {
            book.Language = Language.EN;

            this.context.Book.Add(book);
            //this.context.Book_C.Add(book.CommonEntity);

        }

    }
}
