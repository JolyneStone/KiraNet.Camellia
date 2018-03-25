using System;
using KiraNet.Camellia.Infrastructure.DomainModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KiraNet.Camellia.Infrastructure.Data.EntityConfiguration
{
    public abstract class EntityConfiguration<TEntity, TPrimaryKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity<TPrimaryKey>
         where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        public void Configure(EntityTypeBuilder<TEntity> entity)
        {
            // use: ModelBuilder.ApplyConfiguration(IEntityTypeConfiguration entity);
            entity.HasKey(e => e.Id);
            ConfigureDerived(entity);
        }

        protected abstract void ConfigureDerived(EntityTypeBuilder<TEntity> entity);
    }

    public abstract class EntityConfiguration<TEntity> : EntityConfiguration<TEntity, int>
    where TEntity : class, IEntity
    {
    }
}
