namespace Sisyphus.Core.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class SessionService
    {
        public Session CreateSession(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var session = CreateSession(userName, context);
                    context.SaveChanges();
                    tran.Commit();
                    return session;
                }
            }
        }

        private static Session CreateSession(string userName, SisyphusContext context)
        {
            var user = context.Users.Single(u => u.UserName == userName);

            var session = new Session() { Date = SisyphusDateTime.DateTimeAdapter.Now, User = user };
            context.Sessions.Add(session);
            return session;
        }

        public void SelectStoryForSession(string userName, string storyName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = GetLatestSession(userName, context);
                if (session == null) throw new ArgumentException("userName has no active session", "userName");
                
                SetStoryOnSession(storyName, context, session);
                context.SaveChanges();
            }
        }

        private static void SetStoryOnSession(string storyName, SisyphusContext context, Session session)
        {
            var story = context.Stories.Single(
                s => s.Name == storyName && s.Users.Any(u => u.UserName == session.User.UserName));
            session.Story = story;
        }

        public Session GetSessionForUser(string userName)
        {
            var timeoutMins = int.Parse(Config.Get(Config.SessionTimeOutStringName));
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var session = GetLatestSession(userName, context);
                    if (session == null)
                    {
                        CreateSession(userName, context);
                        context.SaveChanges();
                        session = GetLatestSession(userName, context);
                    }
                    else if (session.Date.AddMinutes(timeoutMins) < SisyphusDateTime.DateTimeAdapter.Now)
                    {
                        var newSession = CreateSession(userName, context);
                        context.SaveChanges();
                        if (session.Story != null)
                        {
                            SetStoryOnSession(session.Story.Name, context, newSession);
                            context.SaveChanges();
                        }

                        session = GetLatestSession(userName, context);
                    }
                    tran.Commit();
                    return session;
                }
            }
        }

        private static Session GetLatestSession(string userName, SisyphusContext context)
        {
            return
                context.Sessions
                    .Where(s => s.User.UserName == userName)
                    .Include(s=>s.User)
                    .Include(s=>s.Story)
                    .OrderByDescending(s => s.Date)
                    .FirstOrDefault();
        }
    }
}