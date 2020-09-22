using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace multiLingual_approach2
{
    public static class ModelBuilderExtensions
    {
        //public static EntityTypeBuilder<TEntity> BuildTranslation<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
        //{
        //    if(typeof(TEntity).IsAssignableFrom(typeof(TranslatableEntityBase<>)))
        //    {
        //        throw new Exception($"{typeof(TEntity).FullName} must inherit from {typeof(TranslatableEntityBase<>).FullName}");
        //    }


        //    builder.HasOne("Entity").WithMany().HasForeignKey("EntityId");
        //    builder.HasOne("Language").WithMany().HasForeignKey("LanguageId");

        //    builder.HasKey("EntityId", "LanguageId");

        //    return builder;
        //}

        //public static void BuildTranslation<TEntity>(this EntityTypeBuilder<TEntity> builder, Action<EntityTypeBuilder<TEntity>> pAction) where TEntity : class
        //{
        //    if (typeof(TEntity).IsAssignableFrom(typeof(TranslatableEntityBase<>)))
        //    {
        //        throw new Exception($"{typeof(TEntity).FullName} must inherit from {typeof(TranslatableEntityBase<>).FullName}");
        //    }


        //    builder.HasOne("Entity").WithMany().HasForeignKey("EntityId");
        //    builder.HasOne("Language").WithMany().HasForeignKey("LanguageId");

        //    builder.HasKey("EntityId", "LanguageId");

        //    pAction(builder);
        //}

        //public static void BuildTranslation<TEntity, TEntityC>(this EntityTypeBuilder<TEntity> builder, Action<EntityTypeBuilder<TEntity>> pAction, Action<EntityTypeBuilder<EntityTypeBuilder<TEntityC>>> pActionC)
        //    where TEntity : TranslatableEntityBase<TEntityC>
        //    where TEntityC : class, new()
        //{
        //    if (typeof(TEntity).IsAssignableFrom(typeof(TranslatableEntityBase<>)))
        //    {
        //        throw new Exception($"{typeof(TEntity).FullName} must inherit from {typeof(TranslatableEntityBase<>).FullName}");
        //    }


        //    builder.HasOne("Entity").WithMany().HasForeignKey("EntityId");
        //    builder.HasOne("Language").WithMany().HasForeignKey("LanguageId");

        //    builder.HasKey("EntityId", "LanguageId");

        //    pAction(builder);

        //}


        public static void BuildTranslation<TEntity, TEntityC>(this ModelBuilder builder, Action<EntityTypeBuilder<TEntity>> pAction, Action<EntityTypeBuilder<TEntityC>> pActionC)
           where TEntity : TranslatableEntityBase<TEntityC>
           where TEntityC : EntityBase, new()
        {
            //if (typeof(TEntity).IsAssignableFrom(typeof(TranslatableEntityBase<>)))
            //{
            //    throw new Exception($"{typeof(TEntity).FullName} must inherit from {typeof(TranslatableEntityBase<>).FullName}");
            //}

            builder.Entity<TEntity>(entityBuilder =>
            {
                entityBuilder.ToTable($"{typeof(TEntity).Name}_T");
                entityBuilder.HasOne("CommonEntity").WithMany().HasForeignKey("CommonEntityId");
                entityBuilder.HasOne("Language").WithMany().HasForeignKey("LanguageId");

                entityBuilder.HasKey("CommonEntityId", "LanguageId");

                pAction(entityBuilder);
            });


            builder.Entity<TEntityC>(entityBuilder =>
            {
                entityBuilder.HasKey(k => k.Id);
                entityBuilder.Property(p => p.Id);

                pActionC(entityBuilder);
            });
        }

    }
}
