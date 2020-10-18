using System;

namespace CSERP.DATA.Infrastructure.HRM.Commands
{
    public class DeleteHRMCompanyCommand : ICommand
    {
        public Guid ID { get;  set; }
    }
}
