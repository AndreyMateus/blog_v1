using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Blog;

public class Program
{
    public static void Main()
    {
        // Populando o banco com dados ficticios
        using AppDBContext appDbContext = new();
        PupulationDatabase(appDbContext);
        
        // var posts = GetPosts(appDbContext,0, 25);
        // Console.WriteLine(posts);
        
        // TODO: criar query simples só que ao invés de uma CLASE em arquivo, você criará uma CLASSE VIRTUAL chamada PostWithTagsCOunt, que terá um nome e um Contador, basicamente esse model simulará uma QUERY no banco, retornará o número de quantas Tags tem em um post, e trará o nome da tag.
        
    }
    // TODO: TERMINAR O MÉTODO de CRIAÇÃO de DADOS para o BANCO
    public static void PupulationDatabase(AppDBContext appDbContext)
    {
        User user = new()
        {
            Name = "Andrey Mateus",
            Email = "andrymateusrj@hotmail.com",
            Bio = "Junior .NET C#",
            ImageUrl = "https://linkImageUrl.com",
            Password = "123#123",
            Slug = "andreymateus",
        };
        
        User userReturned = appDbContext.Users.FirstOrDefault(x => x.Id == 2);
        
        Post post = new()
        {
           User = userReturned,
            Slug = "eldenringpost",
            Title = "New game Elden ring",
            Summary = "Elden ring is a game of rpg created by fromsoftware enterprise",
            Body = "<p>Any things about elden ring here</p>",
            LastUpdateDate = DateTime.UtcNow,
            Category = new Category()
            {
                Name = "Teste",
                Slug = "teste"
            }
        };
    

        // TODO: Populando tabelas RELACIONAMENTO
        // var roleUser = appDbContext.Set<Dictionary<string, Object>>("RoleUser");
        // roleUser.Add();
 
        // var tagPost = appDbContext.Set<Dictionary<string, Object>>("TagPost");
        // tagPost.Add();

    }

    public static List<Post> GetPosts(AppDBContext appDbContext, int skip , int take)
    {
        var contextPots = appDbContext.Posts
            .AsNoTracking()
            // Paginando os dados - para que não trave o servidor
            .Skip(skip)
            .Take(take)
            .ToList();
        return contextPots;
    }
    public static List<Post> GetPostsAndUserRoles(AppDBContext appDbContext, int skip , int take)
    {
        var contextPots = appDbContext.Posts
            .AsNoTracking()
            // Fazendo um JOIN de Posts com User - EAGER LOADING - Explicitando oque eu quero que carregue.
            .Include(post => post.User)
                // Fazendo um SubSelect - tome cuidado com a quantidade de ThenIncludes, afeta a performance, se for o caso de muitas QUERYS, é melhor que você mapeie elas como model e adicione a quem quer fazer a query, assim evitará do theInclude().
                .ThenInclude(user => user.Roles)
            .Skip(skip)
            .Take(take)
            .ToList();
        return contextPots;
    }
  
    public static IQueryable GetPostsAndUserRolesOtimized(AppDBContext appDbContext, int skip , int take)
    {
        var contextPots = appDbContext
                .Posts
                .AsNoTracking()
                .Include(post => post.User)
                .ThenInclude(user => user.Roles)
                // OBS: Se atente também em montar um objeto de classe anônima pra receber somente das COLUNAS da CONSULTA QUE você quer, isso otimizará a query.
                .Select(x => new
                {
                    Id = x.Id,
                    PostTitle = x.Title,
                    UserPost = x.User.Name,
                    UserId = x.User.Id,
                })
                .Skip(skip)
                .Take(take);
        
        return contextPots;
    }
}