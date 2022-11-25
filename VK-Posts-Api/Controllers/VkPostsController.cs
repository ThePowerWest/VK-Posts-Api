using Microsoft.AspNetCore.Mvc;
using VK_Posts_Api.DAL.Interfaces;
using VK_Posts_Api.Models;
using VK_Posts_Api.Services;
using VK_Posts_Api.Services.Interfaces;

namespace VK_Posts_Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с программой
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class VkPostsController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly ILetterService letterService;
        private readonly IRepository<Result> repository;
        private readonly ILogger<VkPostsController> logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="_repository"></param>
        public VkPostsController(ILogger<VkPostsController> _logger,
            IRepository<Result> _repository,
            ILetterService _letterService,
            IPostService _postService)
        {
            logger = _logger;
            repository = _repository;
            letterService = _letterService;
            postService = _postService;
        }

        /// <summary>
        /// Подсчет одинаковых букв в 5 последних постах пользователя Vk
        /// </summary>
        /// <remarks>
        /// Берет 5 последних постов пользователя Vk и считает в них вхождение одинаковых букв(Всех языков).
        /// Результат подсчета записывается в БД, куда также прилагаются посты, из которых брался текст.
        /// </remarks>
        /// <response code="200">Подсчет завершен успешно</response>
        /// <response code="400">В постах пользователя не было букв</response>
        /// <response code="404">Не удалось найти посты</response>
        /// <param name="userId">
        /// Id пользователя Vk. 
        /// Вводить нужно именно Id, а не ссылку на страницу, например: kominessa или id170183239
        /// </param>
        [HttpGet(Name = "GetPosts")]
        public async Task<IActionResult> GetAsync(string userId)
        {
            logger.LogInformation("Начинаю подсчет");

            var posts = await postService.SearchAsync(userId.Replace(" ", ""));

            if (posts != null)
            {
                var counts = letterService.CountUp(posts);

                if (counts != null)
                {
                    await repository.AddAsync(new Result
                    {
                        Posts = posts,
                        Counts = counts
                    });

                    logger.LogInformation("Подсчет закончен");
                    return Ok("Подсчет завершен успешно");
                }
                else
                {
                    logger.LogInformation("В постах нет букв");
                    return BadRequest("В постах пользователя не было букв");
                }
            }
            else
            {
                logger.LogInformation("Не нашел посты");
                return NotFound("Не могу найти посты. Проверьте Id пользователя и убедитесь, что у него открытая страница и стена, и на ней есть посты");
            }
        }
    }
}