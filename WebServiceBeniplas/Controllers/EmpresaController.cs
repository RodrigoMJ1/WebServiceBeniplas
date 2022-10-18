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
        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "EguwnkcfX8b28qSC8GPjX2rGQ3Bfa009ksx6B4YR",
            BasePath = "https://pusharduino-24bd1-default-rtdb.firebaseio.com/"
        };

        Model1 bd = new Model1();

        [ActionName("CargarDatosEmpresa")]
        [HttpGet]
        //funcion para cargar datos de una empresa nueva
        public IHttpActionResult CargarDatosEmpresa(string nombreEmpresa)
        {
            {
                bool flag = false;
                SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
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
