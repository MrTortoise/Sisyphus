using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisyphus.Core.Repository
{
    using System.Data.Entity.Infrastructure;

    public class SisyphusContextFactory : IDbContextFactory<SisyphusContext>
    {
        public SisyphusContext Create()
        {
            return new SisyphusContext(Config.GetConnectionString());
        }
    }
}
