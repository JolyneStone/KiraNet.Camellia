﻿using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KiraNet.Camellia.AuthorizationServer.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=Camellia.AuthorizationServer;Data Source=.\\sqlexpress;MultipleActiveResultSets=true;MultipleActiveResultSets=true");

            return new PersistedGrantDbContext(optionsBuilder.Options, new OperationalStoreOptions());
        }
    }
}
