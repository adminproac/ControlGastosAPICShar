using WebAPICtrlGastos.CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace WebAPICtrlGastos.CapaDatos
{
    public class ServiciosDAL:CadenaDAL
    {
        public List<ServiciosCLS> getServicios(int iidservicio=0)
        {
            List<ServiciosCLS>? list = new List<ServiciosCLS>();
            using (SqlConnection cnx = new SqlConnection(getCadena()))
            {
                try
                {
                    cnx.Open();
                    using(SqlCommand cmd =new SqlCommand("getServicios",cnx))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidservicio", iidservicio);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        { 
                            if (dr!=null)
                            {
                                ServiciosCLS oserviciosCLS;
                                while (dr.Read())
                                { 
                                    oserviciosCLS= new ServiciosCLS();
                                    oserviciosCLS.iidservicio = dr.GetInt32("iidservicio");
                                    oserviciosCLS.nombre = dr.GetString("nombre");
                                    list.Add(oserviciosCLS);
                                }

                            }
                        }
                    }
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    list = null;
                    cnx.Close();
                }
            }
            return list;
        }

        public string delServicio(int iidservicio) 
        {
            string respuesta = "Ha ocurrido un error";

            using (SqlConnection cnx = new SqlConnection(getCadena()))
            {
                try
                {
                    cnx.Open();
                    using(SqlCommand cmd = new SqlCommand("[delServicioById]", cnx))
                    {
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidservicio", iidservicio);
                        int resp=cmd.ExecuteNonQuery();
                        if (resp > 0)
                        {
                            respuesta = "Registro borrado con exito";
                        }
                    }
                    cnx.Close();
                }
                catch(Exception ex)
                {
                    respuesta = "Ha ocurrido un error. " + ex.Message;
                    cnx.Close();
                }
            }

            return respuesta;
        }

        public string insOrUpdServicio(ServiciosCLS oServicioCLS)
        {
            string respuesta = "Ha ocurrido un error";
            using (SqlConnection cnx = new SqlConnection(getCadena()))
            {
                try
                {
                    cnx.Open();
                    using (SqlCommand cmd = new SqlCommand("insOrUpdServicio", cnx))
                    { 
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidservicio", oServicioCLS.iidservicio);
                        cmd.Parameters.AddWithValue("nombre", oServicioCLS.nombre);
                        int resp=cmd.ExecuteNonQuery();
                        if (resp > 0)
                        {
                            string evento = (oServicioCLS.iidservicio == 0) ? "Insertado" : "Actualizado";
                            respuesta = "Registro " + evento  + " con exito.";
                        }
                    }
                    cnx.Close();
                }
                catch (Exception ex)
                {
                    respuesta = "Ha ocurrido un error." + ex.Message;
                    cnx.Close();
                }
            }

            return respuesta;




        }
    }
}
