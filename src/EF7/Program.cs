using System.Collections.Generic;
using EF7.Data;
using EF7.Data.Interfaces;
using EF7.Data.Repositories;
using EF7.Domain;
using Microsoft.EntityFrameworkCore;

namespace EF7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var opt = new DbContextOptionsBuilder<RootContext>();
            opt.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ef7-test-db; Integrated Security=True;");
            //opt.UseInMemoryDatabase();

            using (IDbContext db = new RootContext(opt.Options))
            {
                var rep = new Repository(db);

                var parent = new Parent
                {
                    Name = "Parent",
                    Childs = new List<Child>
                    {
                        new Child {Name = "Child1", Toys = new List<Toy>
                        {
                            new Toy { Name = "Toy1"},
                            new Toy { Name = "Toy2"},
                        }},
                        new Child {Name = "Child1"}
                    }
                };

                rep.Insert(parent);
                rep.SaveChanges();
            }
        }
    }
}
