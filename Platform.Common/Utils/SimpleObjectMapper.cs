using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.common.Utils
{
    public static class SimpleObjectMapper
    {
        public static IList<TTarget> ListMap<TSource, TTarget>(IList<TSource> sourceList)
        {
            CreateMap<TSource, TTarget>();
            return AutoMapper.Mapper.Map<IList<TSource>, IList<TTarget>>(sourceList);
        }
        public static TTarget CreateTargetObject<TSource, TTarget>(TSource sourceObj)
        {
            CreateMap<TSource, TTarget>();
            return AutoMapper.Mapper.Map<TSource, TTarget>(sourceObj);
        }

        private static void CreateMap<TSource, TTarget>()
        {
            AutoMapper.TypeMap typeMap = AutoMapper.Mapper.FindTypeMapFor<TSource, TTarget>();
            if(typeMap== null )
                AutoMapper.Mapper.CreateMap<TSource, TTarget>();
        }
    }

    
}
