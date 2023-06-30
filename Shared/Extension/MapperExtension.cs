using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Dotnet_CRUD.Shared.Extension
{
    public class MapperExtension
    {
        public static Mapper GetMapper<T1, T2>()
        {
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<T1, T2>();
              });
            Mapper mapper = new Mapper(config);
            return mapper;
        }

    }
}