//using IdentityServer4.EntityFramework.DbContexts;
//using IdentityServer4.EntityFramework.Options;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace KiraNet.Camellia.AuthorizationServer.Data
//{
//    public class ConfigurationDbContextFactory: IDesignTimeDbContextFactory<ConfigurationDbContext>
//    {
//        public ConfigurationDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>();
//            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=Camellia.AuthorizationServer;Data Source=.\\sqlexpress;MultipleActiveResultSets=true");

//            return new ConfigurationDbContext(optionsBuilder.Options, new ConfigurationStoreOptions());
//        }
//    }
//}
