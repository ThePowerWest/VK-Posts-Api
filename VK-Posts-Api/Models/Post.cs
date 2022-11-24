namespace VK_Posts_Api.Models
{
    /// <summary>
    /// Модель поста VK для БД
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на пост
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Текст в посте
        /// </summary>
        public string Text { get; set; }
    }
}