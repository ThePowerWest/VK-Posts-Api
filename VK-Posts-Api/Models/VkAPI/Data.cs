using Newtonsoft.Json;

namespace VK_Posts_Api.Models.VkAPI
{
    /// <summary>
    /// Модель данных для дессериализации
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Ветка response
        /// </summary>
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}