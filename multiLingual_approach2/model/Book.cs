using multiLingual_approach2.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public class Book: TranslatableEntityBase<Book_C>
    {
        public string Name { get; set; }
    }

    public class Book_C : EntityBase
    {
        public double Price { get; set; }
    }

}
