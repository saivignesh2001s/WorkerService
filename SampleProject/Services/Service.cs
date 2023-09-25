using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SampleProject.DatabaseContext;
using SampleProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Services
{
    public class Service : IService
    {
        private readonly IConfiguration _configuration;
        public Service(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public bool AddData(Data p)
        {
            int k=0;
           string? connectionString = _configuration.GetConnectionString("ConnString1")?.ToString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (SqlCommand cmd = new SqlCommand("[dbo].[Procedure]", sqlConnection)) { 


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@param1",p.Id);
                cmd.Parameters.AddWithValue("@param2",p.CreatedDate);
                cmd.Parameters.AddWithValue("@param3",p.CreatedTime);
                 k =cmd.ExecuteNonQuery();
     

           }
            if (k == 1)
            {
                sqlConnection.Close();
                return true;
                
            }
            else
            {
                sqlConnection.Close();
                return false;
               
            }
        }
    }
}
