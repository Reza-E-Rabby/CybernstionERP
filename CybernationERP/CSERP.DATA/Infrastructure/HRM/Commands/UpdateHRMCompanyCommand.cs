using System;
using System.Collections.Generic;
using System.Text;

namespace CSERP.DATA.Infrastructure.HRM.Commands
{
    public class UpdateHRMCompanyCommand : ICommand
    {
        public Guid ID { get; set; }
        public string CompanyName { get; set; }
        public string LocationDescription { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
