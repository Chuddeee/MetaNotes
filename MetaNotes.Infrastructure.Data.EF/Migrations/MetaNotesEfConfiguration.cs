using System.Data.Entity.Migrations;
using System.Linq;

namespace MetaNotes.Infrastructure.Data.EF
{
    public sealed class MetaNotesEfConfiguration : DbMigrationsConfiguration<MetaNotesContext>
    {
        public MetaNotesEfConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MetaNotesContext context)
        {
            //предзаполняем бд
            if(!context.Users.Any())
            {
                var users = UsersSeed.GenerateUsers();

                foreach(var user in users)
                {
                    var notes = NotesSeed.GenerateNotes();

                    foreach(var note in notes)
                    {
                        user.UserNotes.Add(note);
                    }
                }

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
