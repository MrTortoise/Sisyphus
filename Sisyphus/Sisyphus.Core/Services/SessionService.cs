namespace Sisyphus.Core.Services
{
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class SessionService
    {
        public Session CreateSession(string userName, string storyName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var user = context.Users.Single(u => u.UserName == userName);
                    var story = context.Stories.SingleOrDefault(s => s.Name == storyName);

                    var session = new Session() { Date = SisyphusDateTime.DateTimeAdapter.Now, Story = story, User = user };
                    context.Sessions.Add(
                        session);
                    context.SaveChanges();
                    tran.Commit();
                    return session;
                }
            }
        }

        public Session GetSessionForUser(string userName)
        {
            var timeoutMins = int.Parse(Config.Get(Config.SessionTimeOutStringName));
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = GetLatestSession(userName, context);
                if (session == null)
                {
                    this.CreateSession(userName, null);
                    session = GetLatestSession(userName, context); 
                }else 
                    if (session.Date.AddMinutes(timeoutMins) < SisyphusDateTime.DateTimeAdapter.Now)
                {
                    this.CreateSession(userName, session.Story.Name);
                    session = GetLatestSession(userName, context);
                }

                return session;
            }

        }

        private static Session GetLatestSession(string userName, SisyphusContext context)
        {
            return context.Sessions.Include("User").Include("Story").Where(s => s.User.UserName == userName).OrderByDescending(s => s.Date).First();
        }
    }
}