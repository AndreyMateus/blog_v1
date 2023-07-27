using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog;

public class Program
{
    public static void Main()
    {
        // Populando o banco com dados ficticios
        using AppDBContext appDbContext = new();
        PupulationDatabase(appDbContext);
       
        
        // Query sem Tracking
        var categories = appDbContext.Categories.AsNoTracking().Select(x => x.Name).ToList();

        //TODO: usar o Include e o thenInclude em uma Query.


        // TODO: Fazer uma páginação usando Skip e Take.

        
        //TODO: usar Eager loading
        

    
        // TODO: criando query simples só que ao invés de uma CLASE em arquivo, você criará uma CLASSE VIRTUAL chamada PostWithTagsCOunt, que terá um nome e um Contador, basicamente esse model simulará uma QUERY no banco, retornará o número de quantas Tags tem em um post, e trará o nome da tag.

    }

    // TODO: TERMINAR O MÉTODO de CRIAÇÃO de DADOS para o BANCO
    public static void PupulationDatabase(AppDBContext appDbContext)
    {
        // Inserindo dados no banco.
        Category category = new()
        {
            Name = "Action",
            Slug =  "action"
        };
        Post post = new()
        {
            Slug = "",
            Title = "New game Elden ring",
            Summary = "Elden ring is a game of rpg created by fromsoftware enterprise",
            Body = "<p>Any things about elden ring here</p>",
            LastUpdateDate = DateTime.UtcNow
        };
        Role role = new()
        {
            Name = "Manager",
            Slug = "manager"
        };
        Tag tag = new()
        {
            Name = ""
        };
        User user = new()
        {
            Name = "",
            Email = "",
            Bio = "",
            ImageUrl = "",
            Password = ""
        };
        
        // Populando tabelas RELACIONAMENTO
        var roleUser = appDbContext.Set<Dictionary<string, Object>>("RoleUser");
        roleUser.Add();
        
        var tagPost = appDbContext.Set<Dictionary<string, Object>>("TagPost");
        tagPost.Add();
    }
}