﻿using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public class Book:TranslatableEntity<Book_T>
    {
        public double Price { get; set; }
    }

}
