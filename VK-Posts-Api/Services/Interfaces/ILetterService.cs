using VK_Posts_Api.Models;

namespace VK_Posts_Api.Services.Interfaces
{
    /// <summary>
    /// Сервис для подсчета букв
    /// </summary>
    public interface ILetterService
    {
        /// <summary>
        /// Посчитать буквы в постах
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        public List<Letter> CountUp(List<Post> posts);
    }
}