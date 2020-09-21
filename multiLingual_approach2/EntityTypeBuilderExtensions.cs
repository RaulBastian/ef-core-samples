using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public static class EntityTypeBuilderExtensions
    {
        public static void BuildTranslation<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
        {
            if(typeof(TEntity).IsAssignableFrom(typeof(TranslationBase<>)))
            {
                throw new Exception($"{typeof(TEntity).FullName} must inherit from {typeof(TranslationBase<>).FullName}");
            }


            builder.HasOne("Entity").WithMany().HasForeignKey("EntityId");
            builder.HasOne("Language").WithMany().HasForeignKey("LanguageId");

            builder.HasKey("EntityId", "LanguageId");
        }
    }
}
