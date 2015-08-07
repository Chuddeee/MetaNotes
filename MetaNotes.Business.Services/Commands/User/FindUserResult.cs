using MetaNotes.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaNotes.Business.Services
{
    public class FindUserResult : BaseCommandResult
    {
        public User User { get; set; }
    }
}
