namespace Blog.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    public Category Category { get; set; }
    // TODO: public int CategoryId { get; set; } - Devo ou não usar
    
    public User User{ get; set; }
    // TODO: public int UserId { get; set; } - Devo ou não usar
    
    public List<Tag> Tags { get; set; } 
}
