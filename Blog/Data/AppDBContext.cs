using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data;

public class AppDBContext : DbContext
{
    // TODO Mapear todas as tabelas em memória
   public DbSet<Tag> Tags {get; set;}


    // TODO: Fazer a conexão com o banco

    // TODO: Aplicar o Mapeamento
}
