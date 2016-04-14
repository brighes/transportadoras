﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carriers.Mvc.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings() {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMapping>();
                x.AddProfile<ViewModelToDomainMapping>();
            });
        }
        
    }
}