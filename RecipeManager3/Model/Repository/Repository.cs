using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;

namespace RecipeManager3.Model.Repository
{
    abstract class Repository<TContext, TEntity> where TContext : DbContext where TEntity : class
    {
        public virtual void Add(TEntity e)
        {
            using (var context = this.Context()){
                context.Set<TEntity>().Add(e);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity e)
        {
            using (var context = this.Context())
            {
                context.Set<TEntity>().Attach(e);
                context.Set<TEntity>().Remove(e);
                context.SaveChanges();
            }
        }

        public virtual void Update(TEntity e)
        {
            using (var context = this.Context())
            {
                context.Entry(e).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void AddOrUpdate(TEntity e)
        {
            if (!this.Exists(e))
            {
                this.Add(e);
            }
            else
            {
                this.Update(e);
            }
        }

        public TEntity Create()
        {
            using (var context = this.Context()) {
                return context.Set<TEntity>().Create();
            }
        }

        public TEntity Find(params object[] keyValues)
        {
            using (var context = this.Context())
            {
                return context.Set<TEntity>().Find(keyValues);
            }
        }

        public abstract bool Exists(TEntity e);

        public int Count()
        {
            using (var context = this.Context())
            {
                return context.Set<TEntity>().Count();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var context = this.Context())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        protected TContext Context()
        {
            return Activator.CreateInstance<TContext>();
        }

    }
}
