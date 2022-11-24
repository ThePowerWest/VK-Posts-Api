namespace VK_Posts_Api.Models
{
    /// <summary>
    /// Модель буквы
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Буква
        /// </summary>
        public string LetterName { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }
    }
}