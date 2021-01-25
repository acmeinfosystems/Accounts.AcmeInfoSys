//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Acme Info Systems">
//     Author: Sreejith Gopinathan
//     Copyright (c) Acme Info Systems. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Accounts.AcmeInfoSys.Data.Repositories
{
    /// <summary>
    /// Abstracts the basic CRUD operations of entities.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Get the total count of entities in database.
        /// </summary>
        /// <returns>Entity count</returns>
        int GetCount();

        /// <summary>
        /// Get the total count of entities in database which meets the criteria.
        /// </summary>
        /// <param name="expression">Filter criteria.</param>
        /// <returns>Entity count</returns>
        int GetCount(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Get one entity object by unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier of the entity</param>
        /// <returns>Entity object.</returns>
        T Get(long id);

        /// <summary>
        /// Get all entity objects.
        /// </summary>
        /// <returns>Enumerable list of entity objects.</returns>
        List<T> GetAll();

        /// <summary>
        /// Get entities which meets a filter criteria.
        /// </summary>
        /// <param name="expression">Filter criteria.</param>
        /// <returns>Enumerable list of entity objects.</returns>
        List<T> GetAll(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Adds an entity object to database.
        /// </summary>
        /// <param name="entity">Entity object to persist.</param>
        /// <returns>Copy of persisted entity object.</returns>
        T Add(T entity);

        /// <summary>
        /// Add a list of entity objects to databse.
        /// </summary>
        /// <param name="entities">Entity objects to persist.</param>
        /// <returns>Task result</returns>
        void Add(IEnumerable<T> entities);

        /// <summary>
        /// Updates an entity object in the database.
        /// </summary>
        /// <param name="entity">Entity object to update.</param>
        /// <returns>Task result</returns>
        void Update(T entity);

        /// <summary>
        /// Update a list of entity objects in the database.
        /// </summary>
        /// <param name="entities">Entity objects to update.</param>
        /// <returns>Task result</returns>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Removes an entity object from the database.
        /// </summary>
        /// <param name="entity">Entity object to remove.</param>
        /// <returns>Task result</returns>
        void Remove(T entity);

        /// <summary>
        /// Remove a list of entity objects from the database.
        /// </summary>
        /// <param name="entities">Entity objects to remove.</param>
        /// <returns>Task result</returns>
        void Remove(IEnumerable<T> entities);
    }
}
