using ApplicationCore.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;

namespace VK_Posts_Api.DAL
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
    {
        protected readonly MainContext Context;

        /// <summary>
        /// ctor
        /// </summary>
        public EFRepository(MainContext context) : base(context)
        {
            Context = context;
        }
    }
}