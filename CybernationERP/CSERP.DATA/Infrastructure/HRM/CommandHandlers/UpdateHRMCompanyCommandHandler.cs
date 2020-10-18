using CSERP.DATA.Infrastructure.HRM.Commands;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSERP.DATA.Infrastructure.HRM.CommandHandlers
{
    public class UpdateHRMCompanyCommandHandler : ICommandHandler<UpdateHRMCompanyCommand>
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; }

        public UpdateHRMCompanyCommandHandler(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("SqlConnection");
        }
        public void Execute(UpdateHRMCompanyCommand command)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.ExecuteNonQuery($"UPDATE HRM_Company_Info SET CompanyName = '{command.CompanyName}' , LocationDescription = '{command.LocationDescription}' ,UpdatedBy = 'Reza' , UpdatedDateTime = '{command.UpdatedDateTime}' WHERE ID = '{command.ID}'");
            }
        }
    }
}
