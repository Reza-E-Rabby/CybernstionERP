using CSERP.DATA.Infrastructure.HRM.Commands;
using CSERP.MODELS.Models.HRM;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data.SqlClient;

namespace CSERP.DATA.Infrastructure.HRM.CommandHandlers
{
    public class CreateHRMCompanyCommandHandler : ICommandHandler<CreateHRMCompanyCommand>
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; }

        public CreateHRMCompanyCommandHandler(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("SqlConnection");
        }

        public void Execute(CreateHRMCompanyCommand command)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.ExecuteNonQuery(@"INSERT INTO HRM_Company_Info (CompanyName,LocationDescription,CreatedBy,CreateDateTime) VALUES 
                (@CompanyName, @LocationDescription, @CreatedBy, @CreateDateTime)",
                new { command.CompanyName, command.LocationDescription, command.CreatedBy, command.CreateDateTime });
            }
        }
    }
}
