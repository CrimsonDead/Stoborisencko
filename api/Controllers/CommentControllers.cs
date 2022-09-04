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

        [HttpGet("getAll", Name = "GetComments")]
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
                _logger.LogInformation("Comment list is successfully receive");
                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Comment list");
                return BadRequest(ex);
            }
        }

        [HttpGet("getById", Name = "Comment")]
        public ActionResult<Comment> GetCommentById(int id)
        {
            try
            {
                Comment comment = _commentRepository.GetItemById(id);
                if (comment == null)
                {
                    _logger.LogInformation("Comment item is null");
                    return Ok(comment);
                }
                _logger.LogInformation("Comment is successfully receive");
                return Ok(comment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Comment");
                return BadRequest(ex);
            }
        }

        //TODO Create method for creating a reply to a comment

        [HttpPost("createNew", Name = "NewComment")]
        public async Task<ActionResult> CreateCommentAsync([FromForm] Comment comment)
        {
            try
            {
                await _commentRepository.AddAsync(comment);
                _logger.LogInformation("Comment is successfully create");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Comment");
                return BadRequest(ex);
            }
        }

        [HttpPut("change", Name = "ChangeComment")]
        public async Task<ActionResult> UpdateCommentAsync([FromForm] Comment newComment)
        {
            try
            {
                await _commentRepository.UpdateAsync(newComment);
                Comment comment = _commentRepository.GetItemById(newComment.Id);
                _logger.LogInformation("Comment is successfully change");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update Comment");
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete", Name = "DeleteComment")]
        public async Task<ActionResult> DeleteCommentAsync([FromForm] Comment comment)
        {
            try
            {
                await _commentRepository.DeleteAsync(comment);
                _logger.LogInformation("Comment is successfully delete");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Comment");
                return BadRequest(ex);
            }
        }

    }
}