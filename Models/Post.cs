using System;
using System.Collections.Generic;

namespace musicoverflow.models
{
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DatePosted { get; set; } = DateTime.Now;
    public List<Comment> Comments { get; set; } = new List<Comment>();
  }
}