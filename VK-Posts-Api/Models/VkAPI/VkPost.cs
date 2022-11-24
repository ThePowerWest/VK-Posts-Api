using Newtonsoft.Json;

namespace VK_Posts_Api.Models.VkAPI
{
    /// <summary>
    /// Модель поста для дессериализации
    /// </summary>
    public class VkPost
    {
        /// <summary>
        /// Id поста Vk
        /// </summary>
        [JsonProperty("id")]
        public int PostId { get; set; }

        /// <summary>
        /// Id пользователя Vk
        /// </summary>
        [JsonProperty("from_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Текст поста
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}