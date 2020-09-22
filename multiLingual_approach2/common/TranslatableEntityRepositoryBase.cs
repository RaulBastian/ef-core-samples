using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace multiLingual_approach2.repositories
{
    public abstract class TranslatableEntityRepositoryBase<T,J> 
        where T: TranslatableEntityBase<J>  
        where J:EntityBase, new()
    {
        private readonly DbContext context;

        public TranslatableEntityRepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.context.Set<T>().Where(row => row.Language.Id == 1);   
        }

        public virtual void Add(T entity)
        {
            entity.Language = Language.EN; //We would use current thread culture here, or default to an invariant culture
            this.context.Set<T>().Add(entity);
        }

    }
}
