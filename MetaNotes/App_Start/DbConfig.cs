using MetaNotes.Infrastructure.Data.EF;
using System.Data.Entity;

namespace MetaNotes
{
    public class DbConfig
    {
        public static void Configure()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MetaNotesContext, MetaNotesEfConfiguration>());
        }
    }
}