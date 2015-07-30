using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>Заметка пользователя</summary>
    [Table("Notes")]
    public class Note : IEntity
    {
        /// <summary>Id заметки</summary>
        [Key]
        public int Id { get; set; }


        /// <summary>Id пользователя, который создал заметку</summary>
        [Column("User_id")]
        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }

        /// <summary>Id пользователя, который изменил заметку</summary>
        [Column("Changed_by")]
        [ForeignKey("ChangedBy")]
        public Guid? ChangedByUserId { get; set; }


        /// <summary>Дата создания заметки в UTC</summary>
        [Column("Create_time")]
        public DateTime CreatingDate { get; set; }

        /// <summary>Дата изменения заметки в UTC</summary>
        [Column("Change_time")]
        public DateTime? ChangingDate { get; set; }

        /// <summary>Дата удаления заметки в UTC</summary>
        [Column("Delete_time")]
        public DateTime? DeletingDate { get; set; }
        

        /// <summary>Удалена ли заметка</summary>
        public bool IsDeleted { get; set; }

        /// <summary>Заголовок заметки</summary>
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        /// <summary>Тело заметки</summary>
        [MaxLength(BodyMaxLength)]
        public string Body { get; set; }



        #region Навигационне свойства

        /// <summary>Создатель заметки</summary>
        public virtual User Owner { get; set; }

        /// <summary>Пользователь, который в последний раз менял заметку</summary>
        public virtual User ChangedBy { get; set; }

        #endregion


        #region Константы
        
        /// <summary>Минимально допустимый размер заголовка заметки</summary>
        public const int TitleMaxLength = 100;

        /// <summary>Максимально допустимый размер тела заметки</summary>
        public const int BodyMaxLength = 4000;

        #endregion
    }
}
