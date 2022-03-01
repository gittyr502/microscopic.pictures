using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DTO;
namespace project_MicroscopicPicture
{
    public class AutoMapping:Profile
    {
        public AutoMapping() {
           
            CreateMap<Patient, PatientDTO>()
                     .ForMember(dest => dest.PatientId,
                     opts => opts.MapFrom(src => src.Id))
                     .ForMember(dest => dest.FirstName,
                     opts => opts.MapFrom(
                         src => 
                     src.User.FirstName))
                     .ForMember(dest => dest.LastName,
                     opts => opts.MapFrom(src => src.User.LastName))
                     .ForMember(dest => dest.IdNumber,
                     opts => opts.MapFrom(src => src.User.IdNumber))
                     .ReverseMap();
        }

    }
}
