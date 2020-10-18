using CSERP.DATA.Infrastructure.HRM.Queries;
using CSERP.MODELS.Models.HRM;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace CSERP.DATA.Infrastructure.HRM.QueryHandlers
{
    public class GetSingleHRMCompanyQueryHandler : IQueryHandler<GetSingleHRMCompanyQuery, HRMCompanyInfo>
    {
        public IConfiguration _configuration;
        public string ConnectionString { get; }

        public GetSingleHRMCompanyQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public HRMCompanyInfo Query(GetSingleHRMCompanyQuery query)
        {
            HRMCompanyInfo hRMCompanyInfo = new HRMCompanyInfo();
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                string SqlQuery = $"SELECT ID,CompanyName,LocationDescription FROM HRM_Company_Info WHERE ID='{query.ID}'";
                hRMCompanyInfo = sqlConnection.ExecuteQuery<HRMCompanyInfo>(SqlQuery).FirstOrDefault();
            }
            return hRMCompanyInfo;
        }
    }
}
