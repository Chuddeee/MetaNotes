using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Business.Services
{
    public class CreateNoteArgs : ICommandArguments
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsPublic { get; set; }
    }
}
