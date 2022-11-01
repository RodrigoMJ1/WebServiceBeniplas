using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceBeniplas.Models;

namespace WebServiceBeniplas.Controllers
{
    public class AdministradorController : ApiController
    {
        Model1 bd = new Model1();
        //funcion para validar las credenciales del administrador y poder iniciar sesion
        [ActionName("ValidarAdmin")]
        [HttpGet]
        public bool ValidarAdmin(string user, string contrasena)
        {
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select NombreUsuario, Contrasena from Administradors where  NombreUsuario='" + user + "' and Contrasena='" + contrasena + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag=true;
            }
            if(flag == true)
            {
                return flag;
            }
            else
            {
                return flag;
            }
        }
    }
}
