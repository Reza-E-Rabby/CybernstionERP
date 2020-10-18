using System;

namespace CSERP.DATA.Infrastructure.HRM.Commands
{
    public class CreateHRMCompanyCommand : ICommand
    {
        public Guid ID { get; internal set; }
        public string CompanyName { get; set; }
        public string LocationDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
