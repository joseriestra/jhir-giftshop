using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using Entities.Classes;
using Repository.General;
using System.Data.Entity;
using Entities.TableConfig;

namespace Repository.Classes
{
    /// <summary>
    /// Base class for the Data Access Objects.
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected GiftShopDbContext dbContext { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Database context</param>
        public BaseRepository(GiftShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Save an entity
        /// </summary>
        /// <param name="entities">Entity to save</param>
        public virtual void Save(TEntity entity)
        {
            try
            {
                // new entities are saved, otherwise updated
                if (entity.Id == 0)
                {
                    dbContext.Set<TEntity>().Add(entity);
                }
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new EntityException("An error ocurred trying to save the entity!", e);
            }
        }

        /// <summary>
        /// Save a list of entities
        /// </summary>
        /// <param name="entity">List of entities to save</param>
        public virtual void Save(IEnumerable<TEntity> entities)
        {
            try
            {
                foreach (TEntity entity in entities)
                {
                    // new entities are saved, otherwise updated
                    if (entity.Id == 0)
                    {
                        dbContext.Set<TEntity>().Add(entity);
                    }
                }
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new EntityException("An error ocurred trying to save the entity!", e);
            }
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="id">Entity id</param>
        public void Delete(long id)
        {
            TEntity entity = FindById(id);
            if (entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
                dbContext.SaveChanges();
            }
            else
            {
                throw new EntityException("The entity that you're trying to delete doesn't exist!");
            }
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
                dbContext.SaveChanges();
            }
            else
            {
                throw new EntityException("The entity that you're trying to delete doesn't exist!");
            }
        }

        /// <summary>
        /// Delete a list of entities
        /// </summary>
        /// <param name="entities">Entities list</param>
        public void DeleteEntities<TEntity>(IList<TEntity> entities) where TEntity : BaseEntity
        {
            foreach (TEntity entity in entities)
            {
                if (entities != null)
                {
                    dbContext.Set<TEntity>().Remove(entity);
                }
            }
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Create a query object
        /// </summary>
        /// <param name="relationships">Relationships to include</param>
        /// <returns>Query object</returns>
        public IQueryable<TEntity> CreateQuery(params string[] relationships)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>().AsQueryable();
            foreach (string relationship in relationships)
            {
                query = query.Include(relationship);
            }
            return query;
        }

        /// <summary>
        /// Create a query object
        /// </summary>
        /// <param name="filters">Filters</param>
        /// <param name="relationships">Relationships to include</param>
        /// <returns>Query object</returns>
        private IQueryable<TEntity> CreateQuery(IList<Expression<Func<TEntity, bool>>> filters, params string[] relationships)
        {
            IQueryable<TEntity> query = CreateQuery();
            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }
            foreach (string relationship in relationships)
            {
                query = query.Include(relationship);
            }
            return query;
        }

        /// <summary>
        /// Find a list of entities with the filters provided
        /// </summary>
        /// <param name="filters">Filters</param>
        /// <param name="relationships">Relationships to include</param>
        /// <returns>Entities list</returns>
        public IList<TEntity> FindByFilters(IList<Expression<Func<TEntity, bool>>> filters, params string[] relationships)
        {
            IQueryable<TEntity> query = CreateQuery(filters, relationships);
            return query.AsEnumerable().ToList();
        }

        /// <summary>
        /// Find an entity with the filters provided
        /// </summary>
        /// <param name="filters">Filters</param>
        /// <param name="relationships">Relationships to include</param>
        /// <returns>Entity or null if there is not matches</returns>
        public TEntity FindUniqueByFilters(IList<Expression<Func<TEntity, bool>>> filters, params string[] relationships)
        {
            IQueryable<TEntity> query = CreateQuery(filters, relationships);
            return query.AsEnumerable().SingleOrDefault();
        }

        /// <summary>
        /// Find a list of entities with the filters provided with entity framework tracking disabled
        /// </summary>
        /// <param name="filters">Filters</param>
        /// <param name="relationships">Relationships to include</param>
        /// <returns>Entity or null if there is not matches</returns>
        public TEntity FindUniqueByFiltersDetached(IList<Expression<Func<TEntity, bool>>> filters, params string[] relationships)
        {
            IQueryable<TEntity> query = CreateQuery(filters, relationships);
            return query.AsNoTracking().AsEnumerable().SingleOrDefault();
        }

        /// <summary>
        /// Find an entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="relationships">Relationships to include</param>
        /// <returns>Entity or null if there is not matches</returns>
        public TEntity FindById(long id, params string[] relationships)
        {
            IQueryable<TEntity> query = CreateQuery(relationships);
            return query.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Find an entities list
        /// </summary>
        /// <param name="relationships">Relationships to include</param>
        /// <returns>Entities list</returns>
        public IList<TEntity> FindAll(params string[] relationships)
        {
            IQueryable<TEntity> query = CreateQuery(relationships);
            return query.ToList();
        }

        /// <summary>
        /// Create an empty filters list
        /// </summary>
        /// <returns>Empty filters list</returns>
        public IList<Expression<Func<TEntity, bool>>> CreateFiltersList()
        {
            return new List<Expression<Func<TEntity, bool>>>();
        }

        /// <summary>
        /// Create an empty orders list
        /// </summary>
        /// <returns>Empty orders list</returns>
        public IList<Expression<Func<TEntity, TOrderKey>>> CreateOrdersList<TOrderKey>()
        {
            return new List<Expression<Func<TEntity, TOrderKey>>>();
        }

        /// <summary>
        /// Update an entities list adding or deleting the entities
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="newList">New list</param>
        /// <param name="savedList">Saved list</param>
        public void UpdateEntitiesList<TEntity>(IList<TEntity> newList, IList<TEntity> savedList) where TEntity : BaseEntity
        {
            DeleteUnselectedEntities(newList, savedList);
            AddNewSelectedEntities(newList, savedList);
        }

        /// <summary>
        /// Delete the entities that doesn't belong to the list anymore
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="newList">New list</param>
        /// <param name="savedList">Saved list</param>
        private void DeleteUnselectedEntities<TEntity>(IList<TEntity> newList, IList<TEntity> savedList) where TEntity : BaseEntity
        {
            IList<TEntity> unselectedEntities = new List<TEntity>();
            unselectedEntities = savedList.Where(oldEntity => !newList.Select(newEntity => newEntity.Id).Contains(oldEntity.Id)).ToList();
            DeleteEntities(unselectedEntities);
        }

        /// <summary>
        /// Add the new entities to the saved list
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="newList">New list</param>
        /// <param name="savedList">Saved list</param>
        private void AddNewSelectedEntities<TEntity>(IList<TEntity> newList, IList<TEntity> savedList) where TEntity : BaseEntity
        {
            foreach (TEntity newEntity in newList.Where(e => e.Id == 0))
            {
                savedList.Add(newEntity);
            }
        }

        /// <summary>
        /// Update the properties of the entities specified in the action parameter
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="newList">New list</param>
        /// <param name="savedList">Saved list</param>
        /// <param name="updateAction">Update action</param>
        private void UpdateEntities<TEntity>(IList<TEntity> newList, IList<TEntity> savedList, Action<BaseEntity> updateAction) where TEntity : BaseEntity
        {
            foreach (TEntity savedEntity in savedList)
            {
                List<TEntity> entitiesToUpdate = newList.Where(e => e.Id != 0 && e.Id == savedEntity.Id).ToList();
                if (entitiesToUpdate.Count > 0)
                {
                    entitiesToUpdate.ForEach(updateAction);
                }
            }
        }

        /// <summary>
        /// Execute paging query
        /// </summary>
        /// <typeparam name="TSelect">Selection type</typeparam>
        /// <typeparam name="TOrderKey">Order key type</typeparam>
        /// <param name="config">Paging config</param>
        /// <param name="select">Selection</param>
        /// <param name="filters">Filters</param>
        /// <param name="orders">Orders</param>        
        /// <returns>Paging query result</returns>
        protected PagingResult<TSelect> ExecPagingQuery<TSelect, TOrderKey>(PagingConfig config, Expression<Func<TEntity, TSelect>> select,
            IList<Expression<Func<TEntity, bool>>> filters, IList<Expression<Func<TEntity, TOrderKey>>> orders = null)
        {
            try
            {
                PagingResult<TSelect> result = new PagingResult<TSelect>(config);
                IQueryable<TEntity> query = CreateQuery(filters);

                // total row count
                result.TotalRows = query.LongCount();

                // custom orders
                if (orders == null)
                {
                    query = query.OrderBy(e => e.Id);
                }
                else
                {
                    foreach (var order in orders)
                    {
                        query = query.OrderBy(order);
                    }
                }

                // paging
                query = query.Skip(config.PageNum * config.PageSize);
                query = query.Take(config.PageSize);

                // fill query result
                result.Rows = query.Select(select).ToList();

                return result;
            }
            catch (Exception e)
            {
                throw new EntityException("An error ocurred trying to execute the paging query", e);
            }
        }

        /// <summary>
        /// Execute a query without paging
        /// </summary>
        /// <typeparam name="TSelect">Selection Type</typeparam>
        /// <param name="select">Selection</param>
        /// <returns>Query Result</returns>
        protected IList<TSelect> ExecuteQuery<TSelect>(Expression<Func<TEntity, TSelect>> select)
        {
            try
            {
                IQueryable<TEntity> query = CreateQuery();
                List<TSelect> rows = query.Select(select).ToList();
                return rows;
            }
            catch (Exception e)
            {
                throw new EntityException("An error ocurred trying to execute the query", e);
            }
        }
    }
}
