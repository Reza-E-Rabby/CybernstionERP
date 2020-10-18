using System;

namespace CSERP.MODELS.Models.HRM
{
    [Serializable]
    public class HRMCompanyInfo
    {
        //public string ID { get; set; }
        public Guid ID { get; set; }
        public string CompanyName { get; set; }
        public string LocationDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
