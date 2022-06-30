using Microsoft.AspNetCore.Mvc;
using WebAPICtrlGastos.CapaDatos;
using WebAPICtrlGastos.CapaEntidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICtrlGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        // GET: api/<ServiciosController>
        [HttpGet]
        public List<ServiciosCLS> Get(int id) 
        { 
            ServiciosDAL oServiciosDAL = new ServiciosDAL();
            return oServiciosDAL.getServicios(id);

        }

        //// GET api/<ServiciosController>/5
        //[HttpGet("{id}")]
        //public List<ServiciosCLS> Get(int id)
        //{
        //    ServiciosDAL oServiciosDAL = new ServiciosDAL();
        //    return oServiciosDAL.getServicios(id);

        //}

        // POST api/<ServiciosController>
        [HttpPost]
        public string Post(ServiciosCLS oServicioCLS)
        {
            ServiciosDAL oServiciosDAL = new ServiciosDAL();
            return oServiciosDAL.insOrUpdServicio(oServicioCLS);
        }

        //// PUT api/<ServiciosController>/5
        //[HttpPut("{id}")]
        //public void Put(ServiciosCLS oServicioCLS)
        //{
        //    ServiciosDAL oServiciosDAL = new ServiciosDAL();
        //    return oServiciosDAL.insOrUpdServicio(oServicioCLS,"Actualizado");
        //}

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            ServiciosDAL oServiciosDAL = new ServiciosDAL();
            return oServiciosDAL.delServicio(id);
        }
    }
}
