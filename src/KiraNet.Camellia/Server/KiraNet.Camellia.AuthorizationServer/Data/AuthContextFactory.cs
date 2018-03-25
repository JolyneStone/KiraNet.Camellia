using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KiraNet.Camellia.AuthorizationServer.Data
{
    public class AuthContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=Camellia.AuthorizationServer;Data Source=.\\sqlexpress;MultipleActiveResultSets=true");

            return new AuthDbContext(optionsBuilder.Options);
        }
    }
}
