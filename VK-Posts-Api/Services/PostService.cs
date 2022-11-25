using Newtonsoft.Json;
using System.Net;
using VK_Posts_Api.Models;
using VK_Posts_Api.Models.VkAPI;
using VK_Posts_Api.Services.Interfaces;

namespace VK_Posts_Api.Services
{
    /// <summary>
    /// Сервис для получения постов пользователя
    /// </summary>
    public class PostService : IPostService
    {
        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="urls"></param>
        /// <returns></returns>
        public async Task<List<Post>> SearchAsync(string userId)
        {
            List<Post> posts = new();

            string vkToken = Environment.GetEnvironmentVariable("API_KEY");

            string response = await GetAsync($"https://api.vk.com/method/wall.get?domain={userId}&count=5&access_token={vkToken}&v=5.131");
            Data data = JsonConvert.DeserializeObject<Data>(response);

            if (data.Response != null)
            {
                foreach (var post in data.Response.Posts)
                {
                    posts.Add(new Post
                    {
                        Text = post.Text,
                        Link = $"https://m.vk.com/wall{post.UserId}_{post.PostId}"
                    });
                }
                return posts;
            }
            else
                return null;
        }

        /// <summary>
        /// GET запрос
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> GetAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();

            if ((response as HttpWebResponse).StatusCode == HttpStatusCode.OK)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string data = reader.ReadToEnd();

                    return data;
                }
            }
            return null;
        }
    }
}