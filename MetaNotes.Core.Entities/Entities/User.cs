using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetaNotes.Core.Entities
{
    [Table("Users")]
    public class User : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(LoginMinLength)]
        [MaxLength(LoginMaxLength)]
        public string Login { get; set; }

        /// <summary>Хеш пароля</summary>
        public string Password { get; set; }

        /// <summary>Является ли пользователь администратором</summary>
        public bool IsAdmin { get; set; }


        #region Навигационные свойства

        /// <summary>Коллекция заметок, которые создал пользователь</summary>
        public virtual ICollection<Note> UserNotes { get; set; }

        /// <summary>Коллекция заметок, которые редактировал пользователь</summary>
        public virtual ICollection<Note> ChangedNotes { get; set; }

        #endregion


        #region Константы

        /// <summary>Минимальное допустимый размер логина</summary>
        [NotMapped]
        public const int LoginMinLength = 5;

        /// <summary>Максимально допустимый размер логина</summary>
        [NotMapped]
        public const int LoginMaxLength = 20;

        #endregion
    }
}
