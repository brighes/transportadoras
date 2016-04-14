using AutoMapper;
using Carriers.Domain.Entities;
using Carriers.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carriers.Mvc.Mappers
{
    public class ViewModelToDomainMapping : Profile
    {
        public override string ProfileName { get { return "ViewModelToDomainMappings"; } }

        protected override void Configure()
        {
            Mapper.CreateMap<CarrierVm, Carrier>();
        }
    }
}