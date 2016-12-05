using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksBlog.Mapping
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Config { get; private set; }
        
        public static void Configure()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelProfile>();
            });
        }
    }
}