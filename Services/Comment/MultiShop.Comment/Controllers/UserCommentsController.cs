using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dto.UserCommentDtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController(CommentContext _context, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _context.UserComments.ToListAsync();
            var comments = _mapper.Map<List<ResultUserCommentDto>>(values);
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var value = await _context.UserComments.FindAsync(id);

            if (value == null)
                return NotFound();

            var comment = _mapper.Map<GetUserCommentByIdDto>(value);

            return Ok(comment);
        }

        [HttpGet("GetUserCommentsByProductId/{productId}")]
        public async Task<IActionResult> GetUserCommentsById(string productId)
        {
            var values = await _context.UserComments.Where(uc => uc.ProductId == productId).ToListAsync();
            var comments = _mapper.Map<List<ResultUserCommentDto>>(values);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateUserCommentDto createUserCommentDo)
        {
            var userComment = _mapper.Map<UserComment>(createUserCommentDo);
            await _context.UserComments.AddAsync(userComment);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateUserCommentDto updateUserCommentDto)
        {
            var userComment = _mapper.Map<UserComment>(updateUserCommentDto);
            _context.UserComments.Update(userComment);
            await _context.SaveChangesAsync();

            return Ok(updateUserCommentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserComment(int id)
        {
            var value = await _context.UserComments.FindAsync(id);

            if (value == null)
                return NotFound();

            _context.UserComments.Remove(value);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
