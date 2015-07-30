using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace Infrastructure.Data.EF
{
    internal class MetaNotesContext : DbContext
    {
        /// <summary>Заметки пользователя</summary>
        public DbSet<Note> Notes { get; set; }

        /// <summary>Пользователи</summary>
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Sql ce если не указываешь длину строки максимальную или указываешь большую все равно делает 
            //длину строки 4000. Чтобы все-таки создавал Nvarchar(max), надо у проперти указать .IsMaxLength()

            modelBuilder.Entity<User>().Property(x => x.Password).IsMaxLength();

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
