using multiLingual_approach2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace multiLingual_approach2.repositories
{
    public class BookRepository: TranslatableEntityRepositoryBase<Book,Book_C>
    {
        public BookRepository(MultiDbContext context):base(context)
        {

        }
    }
}
