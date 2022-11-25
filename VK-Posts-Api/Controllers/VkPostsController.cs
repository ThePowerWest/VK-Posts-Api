using Microsoft.AspNetCore.Mvc;
using VK_Posts_Api.DAL.Interfaces;
using VK_Posts_Api.Models;
using VK_Posts_Api.Services;
using VK_Posts_Api.Services.Interfaces;

namespace VK_Posts_Api.Controllers
{
    /// <summary>
    /// ���������� ��� ������ � ����������
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
        /// ������� ���������� ���� � 5 ��������� ������ ������������ Vk
        /// </summary>
        /// <remarks>
        /// ����� 5 ��������� ������ ������������ Vk � ������� � ��� ��������� ���������� ����(���� ������).
        /// ��������� �������� ������������ � ��, ���� ����� ����������� �����, �� ������� ������ �����.
        /// </remarks>
        /// <response code="200">������� �������� �������</response>
        /// <response code="400">� ������ ������������ �� ���� ����</response>
        /// <response code="404">�� ������� ����� �����</response>
        /// <param name="userId">
        /// Id ������������ Vk. 
        /// ������� ����� ������ Id, � �� ������ �� ��������, ��������: kominessa ��� id170183239
        /// </param>
        [HttpGet(Name = "GetPosts")]
        public async Task<IActionResult> GetAsync(string userId)
        {
            logger.LogInformation("������� �������");

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

                    logger.LogInformation("������� ��������");
                    return Ok("������� �������� �������");
                }
                else
                {
                    logger.LogInformation("� ������ ��� ����");
                    return BadRequest("� ������ ������������ �� ���� ����");
                }
            }
            else
            {
                logger.LogInformation("�� ����� �����");
                return NotFound("�� ���� ����� �����. ��������� Id ������������ � ���������, ��� � ���� �������� �������� � �����, � �� ��� ���� �����");
            }
        }
    }
}