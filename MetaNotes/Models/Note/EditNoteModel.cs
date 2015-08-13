using MetaNotes.Attributes.Validation;
using MetaNotes.Core.Entities;
using MetaNotes.Internationalization.Errors.Shared;
using MetaNotes.Internationalization.UI.Notes.Edit;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes.Models
{
    public class EditNoteModel
    {
        public int? NoteId { get; set; }

        [Display(ResourceType = typeof(NotesEditUIResources), Name="TitleLabel")]
        [RequiredField]
        [MaxLengthField(Note.TitleMaxLength)]        
        public string Title { get; set; }

        [RequiredField]
        [Display(ResourceType = typeof(NotesEditUIResources), Name = "BodyLabel")]
        [MaxLengthField(Note.BodyMaxLength)]   
        public string Body { get; set; }

        public bool IsPublic { get; set; }

        /// <summary>Может ли текущий пользователь редактировать заметку</summary>
        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }
    }
}
