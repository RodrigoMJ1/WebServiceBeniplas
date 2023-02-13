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
            
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
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
        [ActionName("EmpresaNombre")]
        [HttpGet]

        //funcion que retorna nombre de empresa por id
        public IHttpActionResult EmpresaNombre(int idEmpresa)
        {
            {
                bool flag = false;
                SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
                cnc.Open();
                SqlCommand cmd = new SqlCommand("select Nombre  from Empresas where ID='" + idEmpresa + "'", cnc);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    flag = true;
                }
                if (flag == true)
                {
                    rdr.Close();
                    SqlDataAdapter data = new SqlDataAdapter(cmd);
                    List<EmpresaDTO> list = new List<EmpresaDTO>();
                    DataTable tablaEmpresa = new DataTable();
                    data.Fill(tablaEmpresa);
                    list = (from DataRow dr in tablaEmpresa.Rows
                            select new EmpresaDTO()
                            {
                                Nombre = Convert.ToString(dr["Nombre"])
                            }).ToList();
                    cnc.Close();
                    return Ok(tablaEmpresa);
                }
                else
                {
                    return Ok(false);
                }
            }
        }
    }
}
