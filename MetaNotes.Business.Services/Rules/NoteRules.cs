using MetaNotes.Core.Entities;

namespace MetaNotes.Business.Services
{
    /// <summary>Бизнес правила для заметок</summary>
    public static class NoteRules
    {
        /// <summary>Может ли пользователь редактировать заметку</summary>
        public static bool CanEdit(this Note note, User user)
        {
            if (note == null || user == null)
                return false;

            return user.IsAdmin || note.OwnerId == user.Id;
        }

        /// <summary>Может ли пользователь удалять заметку</summary>
        public static bool CanDelete(this Note note, User user)
        {
            if (note == null || user == null)
                return false;

            return note.OwnerId == user.Id;
        }

        /// <summary>Может ли пользователь просматривать заметку</summary>
        public static bool CanSee(this Note note, User user)
        {
            if (note == null || user == null)
                return false;

            return user.IsAdmin || note.IsPublic || note.OwnerId == user.Id;
        }
    }
}
