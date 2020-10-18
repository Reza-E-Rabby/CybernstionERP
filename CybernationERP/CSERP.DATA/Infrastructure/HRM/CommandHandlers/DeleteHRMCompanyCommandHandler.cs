using CSERP.DATA.Infrastructure.HRM.Commands;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System;
using System.Data.SqlClient;

namespace CSERP.DATA.Infrastructure.HRM.CommandHandlers
{
    public class DeleteHRMCompanyCommandHandler : ICommandHandler<DeleteHRMCompanyCommand>
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; }

        public DeleteHRMCompanyCommandHandler(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("SqlConnection");
        }
        public void Execute(DeleteHRMCompanyCommand command)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.ExecuteNonQuery($"DELETE HRM_Company_Info WHERE ID='{command.ID}'");
            }
        }
    }
}
