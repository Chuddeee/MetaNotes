using System.Collections.Generic;

namespace MetaNotes.Services
{
    public interface IMapper
    {
        /// <summary>Создает новый объект на основании исходного, скопировав данные из полей</summary>
        /// <typeparam name="TSource">Тип объекта источника данных</typeparam>
        /// <typeparam name="TDestination">Тип объекта, в который будут скопированы данные</typeparam>
        /// <param name="source">экземпляр объекта источника данных</param>
        /// <returns>Экземпляр нового объекта</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        IEnumerable<TDestination> MapEnumerable<TSource, TDestination>(IEnumerable<TSource> source);
    }
}
