using MetaNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetaNotes
{
    public class SaveNoteModelBuilderResult
    {
        public bool IsSuccess { get; set; }

        public string Error { get; set; }

        public EditNoteModel Model { get; set; }
    }
}