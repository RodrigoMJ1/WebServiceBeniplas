using beniplas.Model;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
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
    public class SucursalController : ApiController
    {
        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "ljyYjowW3ng0NI9ceQNx15Kl2DCWR0gHqvgBzSyg",
            BasePath = "https://beniplas-643b4-default-rtdb.firebaseio.com/"
        };

        Model1 bd = new Model1();
        //funcion que inserta datos de una nueva sucursal a crear
        [ActionName("CargarDatosSucursal")]
        [HttpPost]
        public int CargarDatosSucursal(Sucursals Sucursal)
        {
            {
                var puertaID = new GuardaValoresDTO();
                bool flag = false;
                SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
                cnc.Open();
                SqlCommand cmd = new SqlCommand("select*  from Sucursals where NumSucursal='" + Sucursal.NumSucursal + "' and Empresa_ID='" + Sucursal.Empresa_ID + "'", cnc);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    flag = true;
                }
                if (flag == false)
                {
                    rdr.Close();
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Sucursals (NumSucursal, Direccion, Gerente_ID, Empresa_ID) VALUES(@NumSucursal, @Direccion, @Gerente_ID, @Empresa_ID)", cnc);

                    cmd2.Parameters.AddWithValue("@NumSucursal", Sucursal.NumSucursal);
                    cmd2.Parameters.AddWithValue("@Direccion", Sucursal.Direccion);
                    cmd2.Parameters.AddWithValue("@Gerente_ID", Sucursal.Gerente_ID);
                    cmd2.Parameters.AddWithValue("@Empresa_ID", Sucursal.Empresa_ID);
                    cmd2.ExecuteNonQuery();
                    client = new FireSharp.FirebaseClient(config);
                    SetResponse response1 = client.Set("Beniplas/" + Sucursal.Empresa + "/" + Sucursal.NumSucursal , puertaID);
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
