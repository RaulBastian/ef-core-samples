using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public class TranslatableEntityBase<T> where T : EntityBase, new()
    {
        public TranslatableEntityBase()
        {
            CommonEntity = new T();
        }

        public Language Language { get; set; }

        public T CommonEntity { get; set; }
    }
}
