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
  public class PostsController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public PostsController(DatabaseContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAllPosts()
    {
      return await _context.Posts.Include(i => i.User).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Post>> NewPost(Post post)
    {
      _context.Posts.Add(post);
      await _context.SaveChangesAsync();
      return post;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Post>> EditPost(int id, [FromBody]Post editedPost)
    {
      var oldPost = await _context.Posts.FirstorDefaultAsync(f => f.id == id);
      oldPost.Title = editedPost.Title;
      oldPost.Description = editedPost.Description;
      await _context.SaveChangesAsync();
      return editedPost;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Post>> DeletePost(int id)
    {
      var oldPost = await _context.Posts.FindAsync(id);
      if (oldPost == null)
      {
        return NotFound();
      }

      _context.Posts.Remove(oldPost);
      await _context.SaveChangesAsync();
      return oldPost;
    }
  }
}