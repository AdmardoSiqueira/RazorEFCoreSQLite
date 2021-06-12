using System;
using System.Linq;

namespace RazorEFCoreSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Contexto())
            {
                //Create
                Console.WriteLine("Inserindo um Novo Blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/novoblog" });
                db.SaveChanges();

                //Read
                Console.WriteLine("Pesquisando Blogs");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();
                Console.WriteLine(blog.Url);

                //Update
                Console.WriteLine("Atualizar Blog Adicionando Post");
                blog.Url = "http://blogs.msdn.com/novoblog";
                blog.Posts.Add(
                    new Post { Titulo = "CRUD", Conteudo = "EF Core" });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Apagar Blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}