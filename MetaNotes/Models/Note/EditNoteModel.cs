using MetaNotes.Core.Entities;
using MetaNotes.Internationalization.Errors.Shared;
using MetaNotes.Internationalization.UI.Notes.Edit;
using System.ComponentModel.DataAnnotations;

namespace MetaNotes.Models
{
    public class EditNoteModel
    {
        public int? NoteId { get; set; }

        [Display(ResourceType = typeof(NotesEditUIResources), Name = "TitleLabel")]
        [Required(ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "Required")]
        [MaxLength(Note.TitleMaxLength,
            ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "MaxLength")]
        public string Title { get; set; }



        [Required(ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(NotesEditUIResources), Name = "BodyLabel")]
        [MaxLength(Note.BodyMaxLength,
            ErrorMessageResourceType = typeof(SharedErrorsResources),
            ErrorMessageResourceName = "MaxLength")]
        public string Body { get; set; }

        public bool IsPublic { get; set; }

        /// <summary>Может ли текущий пользователь редактировать заметку</summary>
        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }
    }
}
