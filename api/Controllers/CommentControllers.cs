using datalayer.Models;
using datalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly IRepository<Comment> _commentRepository;
        public CommentController(ILogger<CommentController> logger, IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
            _logger = logger;

        }

        [HttpGet(Name = "Comments")]
        public ActionResult<IEnumerable<Comment>> GetComments()
        {
            try
            {
                List<Comment> comments = _commentRepository.GetItems().ToList();
                if (comments.Count == 0)
                {
                    _logger.LogInformation("Comment list is clear");
                    return Ok(comments);
                }
                else if (comments == null)
                {
                    _logger.LogInformation("Comment list is null");
                    return Ok(comments);
                }
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Comment list");
                return BadRequest(ex);
            }
        }
    }
}