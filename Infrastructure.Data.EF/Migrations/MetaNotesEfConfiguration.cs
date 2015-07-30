using Infrastructure.Data.EF.SeedData;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF
{
    internal sealed class MetaNotesEfConfiguration : DbMigrationsConfiguration<MetaNotesContext>
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
