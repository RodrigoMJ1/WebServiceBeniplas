using beniplas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceBeniplas.Models;

namespace WebServiceBeniplas.Controllers
{
    public class EmpleadoController : ApiController
    {
        Model1 bd = new Model1();

        [ActionName("CargarDatosEmpleado")]
        [HttpGet]
        public IHttpActionResult CargarDatosEmpleado(int idSucursal)
        {
            List<EmpleadoDTO> list = new List<EmpleadoDTO>();
            DataTable tablaEmpleados = new DataTable();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre, ApellidoP, ApellidoM, NumTel, Status  from Empleadoes where Sucursal_ID='" + idSucursal + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaEmpleados);

                list = (from DataRow dr in tablaEmpleados.Rows
                        select new EmpleadoDTO()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApellidoP = dr["ApellidoP"].ToString(),
                            ApellidoM = dr["ApellidoM"].ToString(),
                            NumTel = long.Parse(dr["NumTel"].ToString()),
                            Status = bool.Parse(dr["Status"].ToString())
                        }).ToList();
                cnc.Close();
                return Ok(list);
            }
            else
            {
                cnc.Close();
                return null;
            }
        }
        [ActionName("ActualizarStatusEmpleado")]
        [HttpGet]

        public IHttpActionResult ActualizarStatusEmpleado(int id, bool status)
        {
            var data = from Empleado in bd.Empleados
                       where Empleado.ID == id
                       select Empleado;

            
            if (status == true)
            {
                status = false;
            }
            else
            {
                status = true;
            }
            Empleado cambio = data.First();
            cambio.Status = status;

            
            if (bd.SaveChanges() == 1)
            {
               return Ok("Modificado status del empleado " + cambio.Nombre.ToString());
            }
            else
            {
                return null;
            }
            

        }
        

            
    }
}
