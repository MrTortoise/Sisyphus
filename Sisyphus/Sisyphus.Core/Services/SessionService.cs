namespace Sisyphus.Core.Services
{
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class SessionService
    {
        public void CreateSession(string userName, string storyName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var user = context.Users.Single(u => u.UserName == userName);
                    var story = context.Stories.SingleOrDefault(s => s.Name == storyName);

                    context.Sessions.Add(
                        new Session() { Date = SisyphusDateTime.DateTimeAdapter.Now, Story = story, User = user });
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }

        public Session GetSessionForUser(string userName)
        {
            var timeoutMins = int.Parse(Config.Get(Config.SessionTimeOutStringName));
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.Sessions.Where(s => s.User.UserName == userName).OrderBy(s => s.Date).FirstOrDefault();
                if (session == null)
                {
                    this.CreateSession(userName, null);
                    session = context.Sessions.Where(s => s.User.UserName == userName).OrderBy(s => s.Date).First(); 
                }else 
                    if (session.Date.AddMinutes(timeoutMins) > SisyphusDateTime.DateTimeAdapter.Now)
                {
                    this.CreateSession(userName, session.Story.Name);
                    session = context.Sessions.Where(s => s.User.UserName == userName).OrderBy(s => s.Date).First();
                }

                return session;
            }

        }
    }
}