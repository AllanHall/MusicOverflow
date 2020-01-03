using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using musicoverflow.models;
using musicoverflow;
using Microsoft.AspNetCore.Http;
using Mircosoft.EntityFrameworkCore;

namespace musicoverflow.controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommentsController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public CommentsController(DatabaseContext context)
    {
      _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Comment>>> GetAllComments()
    {
      return await _context.Comments.Include(i => i.Post).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> PostNewComment(Comment comment)
    {
      _context.Sites.Add(comment);
      await _context.SaveChangesAsync();
      return comment;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Comment>> EditComment(int id, [FromBody]Comment editedComment)
    {
      var oldComment = await _context.Comments.FirstOrDefaultAsync(f => f.id == id);
      oldComment.Description = editedComment.Description;
      await _context.SaveChangesAsync();
      return editedComment;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Comment>> DeleteComment(int id)
    {
      var oldComment = await _context.Comments.FindAsync(id);
      if (oldComment == null)
      {
        return NotFound();
      }

      _context.Comments.Remove(oldComment);
      await _context.SaveChangesAsync();
      return oldComment;
    }
  }
}
