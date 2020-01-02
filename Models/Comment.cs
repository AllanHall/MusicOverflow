using System;

namespace musicoverflow.models
{
  public class Comment
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DatePosted { get; set; } = DateTime.Now;
    public int? PostID { get; set; }
    public Post Post { get; set; }
  }
}