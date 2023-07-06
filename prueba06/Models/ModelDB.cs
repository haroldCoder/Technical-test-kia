using System.Data.SqlClient;

namespace prueba06.Models
{
    public class ModelDB
    {
        protected IConfiguration configuration;

        public ModelDB()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            this.configuration = builder.Build();
        }

        public SqlConnection connection()
        {
            string stringConnection = configuration.GetConnectionString("prueba06");
            SqlConnection conexion = new SqlConnection(stringConnection);
            conexion.Open();
            return conexion;
        }
    }
}
