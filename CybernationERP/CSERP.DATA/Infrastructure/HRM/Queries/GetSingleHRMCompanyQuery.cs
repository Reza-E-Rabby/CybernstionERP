using CSERP.MODELS.Models.HRM;
using System;
using System.Collections.Generic;

namespace CSERP.DATA.Infrastructure.HRM.Queries
{
    public class GetSingleHRMCompanyQuery: IQuery<HRMCompanyInfo>
    {
        public Guid ID { get; set; }
    }
}
