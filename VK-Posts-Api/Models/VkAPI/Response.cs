using Newtonsoft.Json;

namespace VK_Posts_Api.Models.VkAPI
{
    /// <summary>
    /// Ветка response
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Посты
        /// </summary>
        [JsonProperty("items")]
        public IEnumerable<VkPost> Posts { get; set; }
    }
}