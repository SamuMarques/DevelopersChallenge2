using AutoMapper;
using DevelopersChallenge.Nibo.Configurations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(new[]
                {
                    typeof(ExternalTransactionAutoMapperProfile),
                    typeof(InternalTransactionAutoMapperProfile),
                });
            });
        }
    }
}
