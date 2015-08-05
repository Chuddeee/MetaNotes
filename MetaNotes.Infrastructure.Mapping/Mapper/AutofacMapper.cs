using AutoMapper;
using MetaNotes.Services;
using System.Collections.Generic;

namespace MetaNotes.Infrastructure.Mapping
{
    public class AutofacMapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public IEnumerable<TDestination> MapEnumerable<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }
    }
}
