using AutoMapper;
using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Configurations
{
    public class InternalTransactionAutoMapperProfile : Profile
    {
        public InternalTransactionAutoMapperProfile()
        {
            CreateMap<InternalTransactionCrudViewModel, InternalTransaction>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(r => r.Type == "DEBIT" ? -r.Value : r.Value));

            CreateMap<InternalTransaction, InternalTransactionCrudViewModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(r => r.Type == "DEBIT" ? -r.Value : r.Value));
        }
    }
}
