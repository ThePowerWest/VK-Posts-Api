using VK_Posts_Api.Models;

namespace VK_Posts_Api.Services.Interfaces
{
    /// <summary>
    /// Сервис для получения постов пользователя
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<Post>> SearchAsync(string userId);
    }
}