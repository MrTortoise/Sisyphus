namespace Sisyphus.Core.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices;

    using Sisyphus.Core.Model;
    using Sisyphus.Core.Repository;

    public class SexService
    {
        public List<Sex> GetSexes(string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var sexes = context.Sexes.Where(s => s.Story.Id == session.StoryId).ToList();
                return sexes;
            }

        }

        public Sex GetSex(string name, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var sexes = context.Sexes.SingleOrDefault(s => s.StoryId == session.StoryId && s.Name == name);
                return sexes;
            }

        }

        public void Create(string name, string description, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                var session = context.GetSessionForUser(userName);
                var sex = new Sex() { Description = description, Name = name, Story = session.Story };
                context.Sexes.Add(sex);
                context.SaveChanges();
            }
        }

        public void Update(Sex sex)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    context.Entry(sex).State = EntityState.Modified;
                    context.SaveChanges();
                    tran.Commit();
                }
            }
        }

        public void Delete(string name, string userName)
        {
            var conStr = Config.GetConnectionString();
            using (var context = new SisyphusContext(conStr))
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var session = context.GetSessionForUser(userName);
                    var sex = context.Sexes.Single(s => s.Name == name && s.StoryId == session.StoryId);
                    context.Sexes.Remove(sex);
                    context.SaveChanges();
                    tran.Commit();
                }

            }
        }
    }
}