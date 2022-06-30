using Microsoft.Extensions.Configuration;

namespace WebAPICtrlGastos.CapaDatos
{
    public class CadenaDAL
    {
        public string getCadena()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            return configurationBuilder.Build().GetConnectionString("CadenaConexion");
        }

    }
}
