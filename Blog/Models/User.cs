using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Bio { get; set; }
    public string ImageUrl { get; set; }
    public string Slug { get; set; }
    public List<Post> Posts { get; set; }
    public List<Role> Roles { get; set; }
}
