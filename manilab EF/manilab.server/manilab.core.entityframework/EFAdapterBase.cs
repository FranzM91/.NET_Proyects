﻿using manilab.core.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace manilab.core.entityframework
{
    public class EFAdapterBase<T> : IAdapterBase<T> where T : class
    {
        public readonly DbContext context;

        protected EFAdapterBase(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T FindById(string id)
        {
            return context.Set<T>().Find(id);
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> get_asc(Func<T, bool> where, Func<T, object> order)
        {
            return context.Set<T>().Where(where).OrderBy(order).ToList();
        }

        public IEnumerable<T> get_desc(Func<T, bool> where, Func<T, object> order)
        {
            return context.Set<T>().Where(where).OrderByDescending(order).ToList();
        }

        public IEnumerable<T> GetAllOrderBy(Func<T, object> keySelector)
        {
            return context.Set<T>().OrderBy(keySelector).ToList();
        }


        public IEnumerable<T> GetAllOrderByDescending(Func<T, object> keySelector)
        {
            return context.Set<T>().OrderByDescending(keySelector).ToList();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public T Create(T entity)
        {
            return context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public T Delete(T entity)
        {
            return context.Set<T>().Remove(entity);
        }

        public void discart(T entity)
        {
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetPage(int page, int limit, Func<T, object> keySelector)
        {
            page--;
            // IEnumerable<T> enumerable = context.Set<T>().OrderByDescending(keySelector);
            // return enumerable.Skip(page * limit).Take(limit);
            return context.Set<T>().OrderByDescending(keySelector).Skip(page * limit).Take(limit);
        }

        public int Count()
        {
            return context.Set<T>().Count();
        }

        public IEnumerable<T> Where(int page, int limit, Func<T, bool> where, Func<T, object> selector)
        {
            page--;
            return context.Set<T>().Where(where).OrderByDescending(selector).Skip(page * limit).Take(limit);
        }
    }
}
