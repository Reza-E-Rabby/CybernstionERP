using CSERP.DATA.Infrastructure.HRM.Queries;
using CSERP.MODELS.Models.HRM;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using RepoDb;
using System.Linq;

namespace CSERP.DATA.Infrastructure.HRM.QueryHandlers
{
    public class GetAllHRMCompanyQueryHandler : IQueryHandler<GetAllHRMCompanyQuery, IEnumerable<HRMCompanyInfo>>
    {
        public IConfiguration _configuration;
        public string ConnectionString { get; }

        public GetAllHRMCompanyQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IEnumerable<HRMCompanyInfo> Query(GetAllHRMCompanyQuery query)
        {
            List<HRMCompanyInfo> companyList = new List<HRMCompanyInfo>();
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                string SqlQuery = "SELECT ID,CompanyName,LocationDescription FROM HRM_Company_Info";
                companyList = sqlConnection.ExecuteQuery<HRMCompanyInfo>(SqlQuery).ToList();
            }
            return companyList;
        }
    }
}
