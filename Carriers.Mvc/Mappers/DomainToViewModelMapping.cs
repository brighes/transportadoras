using AutoMapper;
using Carriers.Domain.Entities;
using Carriers.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carriers.Mvc.Mappers
{
    public class DomainToViewModelMapping : Profile
    {
        public override string ProfileName { get { return "DomainToViewModelMappings"; } }

        protected override void Configure()
        {
            Mapper.CreateMap<Carrier, CarrierVm>();
        }
    }
}