﻿using GrossMarketApp.Core.Abstract.EntityBases;
using GrossMarketApp.Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrossMarketApp.Api.Dtos.MemberCustomers
{
    public class MemberCustomerDto : DtosBase
    {
        public MemberCustomer MemberCustomer { get; set; }
    }
}
