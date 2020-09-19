using System;
using System.Collections.Generic;
using System.Text;

namespace ownsOne
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string INTERNAL_FullName { get; set; }

        public PersonDetail Detail { get; set; }
    }
}
