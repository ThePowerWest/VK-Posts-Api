namespace VK_Posts_Api.Models
{
    /// <summary>
    /// Модель результатов подсчета для БД
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Буквы и их количество
        /// </summary>
        public List<Letter> Counts { get; set; }

        /// <summary>
        /// Посты, из которых брался текст
        /// </summary>
        public List<Post> Posts { get; set; }
    }
}