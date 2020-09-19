using System;
using System.Collections.Generic;
using System.Text;

namespace manyToOneWithDelete
{
    public class Book
    {
        public int Id { get; set; }

        public virtual Author Author { get; set; }

        public string Name { get; set; }
    }
}
