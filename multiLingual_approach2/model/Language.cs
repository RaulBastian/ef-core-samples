﻿using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public class Language
    {
        public int Id { get; set; }

        public string Short { get; set; }

        public static Language EN = new Language() { Id = 1, Short = "en" };
        public static Language PT = new Language() { Id = 2, Short = "pt" };
    }
}
