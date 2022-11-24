using Microsoft.EntityFrameworkCore;
using VK_Posts_Api.Models;

namespace VK_Posts_Api.DAL
{
    /// <summary>
    /// Контекст данных БД
    /// </summary>
    public class MainContext : DbContext
    {
        /// <summary>
        /// ctor
        /// </summary>
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        /// <summary>
        /// Результаты
        /// </summary>
        public DbSet<Result> Results { get; set; }

        /// <summary>
        /// Посты
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Буквы
        /// </summary>
        public DbSet<Letter> Letters { get; set; }
    }
}