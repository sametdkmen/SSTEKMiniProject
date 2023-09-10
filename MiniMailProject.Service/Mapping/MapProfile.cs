using AutoMapper;
using MiniMailProject.Core.DTOs;
using MiniMailProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SendMail,SendMailDto>().ReverseMap();
            CreateMap<SendMail, ToMailDto>().ReverseMap();           
            CreateMap<Task<SendMailDto>, SendMailDto>();
            CreateMap<SendMail, ToMailDto>().ForMember(dest => dest.To, opt => opt.MapFrom(src => src.To)); //Entity İçindeki To Sütununu Dto ile eşleştirdik.
        }
    }
}
