using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public class TranslationBase<T> where T : class
    {
        public Language Language { get; set; }

        public T Entity { get; set; }
    }
}
