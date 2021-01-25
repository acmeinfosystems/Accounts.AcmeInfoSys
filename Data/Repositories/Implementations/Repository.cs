//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Accounts.AcmeInfoSys.Data.Repositories.Implementations
{
    /// <summary>
    /// Base class for all repository types across the application.
    /// Provides the basic CRUD operations of entities.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private bool disposed = false;
        protected readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get the total count of entities in database.
        /// </summary>
        /// <returns>Entity count</returns>
        public int GetCount()
        {
            return dbContext.Set<T>().Count();
        }

        /// <summary>
        /// Get the total count of entities in database which meets the criteria.
        /// </summary>
        /// <param name="expression">Filter criteria.</param>
        /// <returns>Entity count</returns>
        public int GetCount(Expression<Func<T, bool>> expression)
        {
            return  dbContext.Set<T>().Count(expression);
        }

        /// <summary>
        /// Get one entity object by unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier of the entity</param>
        /// <returns>Entity object.</returns>
        public T Get(long id)
        {
            return dbContext.Set<T>().Find(id);
        }

        /// <summary>
        /// Get all entity objects.
        /// </summary>
        /// <returns>Enumerable list of entity objects.</returns>
        public List<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        /// <summary>
        /// Get entities which meets a filter criteria.
        /// </summary>
        /// <param name="expression">Filter criteria.</param>
        /// <returns>Enumerable list of entity objects.</returns>
        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression).ToList();
        }

        /// <summary>
        /// Adds an entity object to database.
        /// </summary>
        /// <param name="entity">Entity object to persist.</param>
        /// <returns>Copy of persisted entity object.</returns>
        public T Add(T entity)
        {
            var result =  dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// Add a list of entity objects to databse.
        /// </summary>
        /// <param name="entities">Entity objects to persist.</param>
        /// <returns>Task result</returns>
        public void Add(IEnumerable<T> entities)
        {
             dbContext.Set<T>().AddRange(entities);
             dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates an entity object in the database.
        /// </summary>
        /// <param name="entity">Entity object to update.</param>
        /// <returns>Task result</returns>
        public void Update(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Update a list of entity objects in the database.
        /// </summary>
        /// <param name="entities">Entity objects to update.</param>
        /// <returns>Task result</returns>
        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                dbContext.Entry<T>(entity).State = EntityState.Modified;
            }
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes an entity object from the database.
        /// </summary>
        /// <param name="entity">Entity object to remove.</param>
        /// <returns>Task result</returns>
        public void Remove(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Remove a list of entity objects from the database.
        /// </summary>
        /// <param name="entities">Entity objects to remove.</param>
        /// <returns>Task result</returns>
        public void Remove(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
            }
            dbContext.SaveChanges();
        }

        /// <summary>
        /// De-allocating all the resources and disposing the repository object. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}