using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RazorEFCoreSQLite
{
    public class Contexto : DbContext
    {
        public DbSet<Post> Posts {get; set;}
        public DbSet<Blog> Blogs {get; set;}
        
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite(@"Data Source=/home/admardo/Desenvolvimento/RazorEFCoreSQLite/sqlitedb.db");
    }
    public class Post
    {
        public int PostId {get; set;}
        public string Titulo {get; set;}
        public string Conteudo {get; set;}
        public int BlogId {get; set;}
        public Blog Blog {get; set;}       
    }

    public class Blog
    {
        public int BlogId {get; set;}
        public string Url { get; set; }
        
        public List<Post> Posts {get;} = new List<Post>();
    }   
    
}