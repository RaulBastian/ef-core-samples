using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public class TranslatableEntity<J> : EntityBase where J : class
    {
        public J T { get; set; }

    }
}
