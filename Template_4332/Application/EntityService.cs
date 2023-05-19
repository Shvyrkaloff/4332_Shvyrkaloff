using System.Data.Entity;
using System.Linq;

namespace Template_4332.Application
{
    /// <summary>
    /// Class EntityService.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public abstract class EntityService<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// The context
        /// </summary>
        protected ApplicationContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        protected DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityService{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected EntityService(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);

                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Reads as queryable.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public virtual IQueryable<TEntity> ReadAsQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}
