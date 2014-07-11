using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisyphus.Core.Repository
{
    using System.Data.Entity;

    using Sisyphus.Core.Model;

    public static class SessionRepository
    {
        public static Session GetSessionForUser(this SisyphusContext context, string userName)
        {
            var session =
                context.Sessions.Where(s => s.User.UserName == userName)
                    .Include("User")
                    .Include("Story")
                    .OrderByDescending(s => s.Date)
                    .FirstOrDefault();

            return session;
        }
    }
}
