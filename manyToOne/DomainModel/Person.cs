using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToOne.DomainModel
{
    public class Person
    {
        public int Id { get;  set; }
        public string Name { get;  set; }

        public Book FavoriteBook { get;  set; }
    }
}
