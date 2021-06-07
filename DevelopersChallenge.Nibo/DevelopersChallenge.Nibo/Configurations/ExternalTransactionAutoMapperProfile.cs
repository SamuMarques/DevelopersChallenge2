using AutoMapper;
using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Configurations
{
    public class ExternalTransactionAutoMapperProfile : Profile
    {
        public ExternalTransactionAutoMapperProfile()
        {
            CreateMap<TransactionDTO, ExternalTransaction>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(r => r.Type))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(r => ConvertStringToDateTime(r.Date)))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(r => decimal.Parse(r.Value, CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(r => r.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(r => r.Type));
        }

        protected static DateTime ConvertStringToDateTime(string date)
        {
            return DateTime.ParseExact(date.Substring(0, 8), "yyyyMMdd", new CultureInfo("pt-BR"));
        }
    }
}
