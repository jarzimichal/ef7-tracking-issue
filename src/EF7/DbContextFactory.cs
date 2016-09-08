using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EF7.Data;

namespace EF7
{
    public class DbContextFactory : IDbContextFactory<RootContext>
    {
        public RootContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<RootContext>();
            builder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ef7-test-db; Integrated Security=True;");
            return new RootContext(builder.Options);
        }
    }
}
