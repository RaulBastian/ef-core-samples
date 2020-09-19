using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingualConsoleDB.model
{
    public class Language
    {
        public static Language EN = new Language() { Id = 1, Desc = "en" };
        public static Language ES = new Language() { Id = 2, Desc = "es" };
        public static Language PT = new Language() { Id = 3, Desc = "pt" };

        public int Id { get; set; }

        public string Desc { get; set; }

    }
}
