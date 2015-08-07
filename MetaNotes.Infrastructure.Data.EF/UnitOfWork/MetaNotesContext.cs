using MetaNotes.Core.Entities;
using System.Data.Entity;

namespace MetaNotes.Infrastructure.Data.EF
{
    public class MetaNotesContext : DbContext
    {
        /// <summary>Заметки пользователя</summary>
        public DbSet<Note> Notes { get; set; }

        /// <summary>Пользователи</summary>
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Password);

            modelBuilder.Entity<User>()
                .HasMany(x => x.UserNotes)
                .WithRequired(x => x.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(x => x.ChangedNotes)
                .WithOptional(x => x.ChangedByUser)
                .WillCascadeOnDelete(false);
        }
    }
}
