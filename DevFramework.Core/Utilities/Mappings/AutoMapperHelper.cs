using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });

            IMapper mapper = new Mapper(config);
            List<T> result = mapper.Map<List<T>, List<T>>(list);
            return result;
        }

        public static T MapToSameType<T>(T obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });

            IMapper mapper = new Mapper(config);
            T result = mapper.Map<T,T>(obj);
            return result;
        }


    }
}
