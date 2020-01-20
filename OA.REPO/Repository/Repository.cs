using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using Microsoft.EntityFrameworkCore;

namespace OA.REPO.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields

        private readonly EventsOrganizerContext.EventsOrganizerContext _context;

        #endregion

        #region Ctor

        public Repository()
        {
            this._context = new EventsOrganizerContext.EventsOrganizerContext();
        }

        #endregion

        #region Methods

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.Set<T>().Add(entity);
                _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    _context.Set<T>().Add(entity);

                _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.Set<T>().Update(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    _context.Set<T>().Update(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.Set<T>().Remove(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    _context.Set<T>().Remove(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public virtual T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        #endregion
    }
}
