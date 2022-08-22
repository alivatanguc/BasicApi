using AutoMapper;
using HotelFinder.Business.Models;
using OtelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.Business.MapperProfiles
{
   public class CustomerProfile :Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerInfoDto>()
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.FirstName + " " + source.LastName))
                
               .ForMember(destination => destination.CId, operation => operation.MapFrom(source => ((CustomerCIdEnum)source.CId).ToString()));
            // burda mapper işlemleri yaparak istediğimiz formda gözükmesini sağlıyoruz yani isim soisimi sadece name adı altında görmek istiyorum

        }


    }
}
