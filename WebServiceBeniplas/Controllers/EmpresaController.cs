using beniplas.Model;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebServiceBeniplas.Models;

namespace WebServiceBeniplas.Controllers
{
    public class EmpresaController : ApiController
    {

        [ActionName("CargarDatosEmpresa")]
        [HttpGet]
        //funcion para cargar datos de una empresa nueva
        public IHttpActionResult CargarDatosEmpresa(string nombreEmpresa)
        {
            {
                bool flag = false;
                SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
                cnc.Open();
                SqlCommand cmd = new SqlCommand("select*  from Empresas where Nombre='" + nombreEmpresa.ToString() + "'", cnc);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    flag = true;
                }
                if (flag == false)
                {
                    rdr.Close();
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Empresas (Nombre) VALUES(@Nombre)", cnc);

                    cmd2.Parameters.AddWithValue("@Nombre", nombreEmpresa.ToString());
                    cmd2.ExecuteNonQuery();
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
        }
    }
}
