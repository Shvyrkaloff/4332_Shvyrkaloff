using System.Data.Entity;

namespace Template_4332.Application
{
    /// <summary>
    /// Class ApplicationContext.
    /// Implements the <see cref="DbContext" />
    /// </summary>
    /// <seealso cref="DbContext" />
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Gets or sets the ski services.
        /// </summary>
        /// <value>The ski services.</value>
        public DbSet<SkiService> SkiServices { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        public ApplicationContext() : base("AutoService") { }
    }
}
