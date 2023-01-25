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
    public class GerenteController : ApiController
    {

        [ActionName("CargarDatosGerente")]
        [HttpGet]
        //funcion que retorna una lista de gerentes en torno a una region y una empresa en especifico
        public IHttpActionResult CargarDatosGerente(string Region, int id)
        {
            List<GerenteDTO> list = new List<GerenteDTO>();
            DataTable tablaGerentes = new DataTable();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre, ApellidoP, ApellidoM, Region, NumTel, Contrasena, Status  from Gerentes where Region='" + Region + "' and Empresa_ID='" + id + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaGerentes);
                list = (from DataRow dr in tablaGerentes.Rows
                        select new GerenteDTO()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApellidoP = dr["ApellidoP"].ToString(),
                            ApellidoM = dr["ApellidoM"].ToString(),
                            Region = dr["Region"].ToString(),
                            NumTel = long.Parse(dr["NumTel"].ToString()),
                            Status = bool.Parse(dr["Status"].ToString())
                        }).ToList();
            }
            cnc.Close();
            return Ok(list);
        }


        [ActionName("ActualizarStatusGerente")]
        [HttpGet]
        //funcion para solamente actualizar el status de un gerente en torno a su region y su status actual
        public IHttpActionResult ActualizarStatusGerente(string region, int id, bool status)
        {
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select Status from Gerentes where ID='" + id + "' and Region='" + region + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                rdr.Close();
                SqlCommand cmd2 = new SqlCommand("UPDATE Gerentes SET[Status] = @Status where ID='" + id + "' and Region='" + region + "'", cnc);
                if (status == true)
                {
                    status = false;
                    cmd2.Parameters.AddWithValue("@Status", status);
                    cmd2.ExecuteNonQuery();
                    return Ok("Gerente desactivado");
                }
                else
                {
                    status = true;
                    cmd2.Parameters.AddWithValue("@status", status);
                    cmd2.ExecuteNonQuery();
                    return Ok("Gerente activado");
                }
            }
            else
            {
                return Ok("Gerente no encontrado");
            }

        }
        
        [ActionName("InsertarGerente")]
        [HttpPost]
        //funcion para insertar datos de un nuevo gerente a crear
        public IHttpActionResult InsertarGerente(GerenteDTO2 gerente)
        {
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select *  from Gerentes where NombreUsuario='" + gerente.NombreUsuario + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }
            if (flag == false)
            {
                rdr.Close();
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Gerentes (NombreUsuario, Nombre, ApellidoP, ApellidoM, Region, NumTel, Contrasena, Status, Empresa_ID) VALUES(@NombreUsuario, @Nombre, @ApellidoP, @ApellidoM, @Region, @NumTel, @Contrasena, @Status, @Empresa_ID)", cnc);

                cmd2.Parameters.AddWithValue("@NombreUsuario", gerente.NombreUsuario);
                cmd2.Parameters.AddWithValue("@Nombre", gerente.Nombre);
                cmd2.Parameters.AddWithValue("@ApellidoP", gerente.ApellidoP);
                cmd2.Parameters.AddWithValue("@ApellidoM", gerente.ApellidoM);
                cmd2.Parameters.AddWithValue("@Region", gerente.Region);
                cmd2.Parameters.AddWithValue("@NumTel", gerente.NumTel);
                cmd2.Parameters.AddWithValue("@Contrasena", gerente.Contrasena);
                cmd2.Parameters.AddWithValue("@Status", gerente.Status);
                cmd2.Parameters.AddWithValue("@Empresa_ID", gerente.Empresa_ID);
                cmd2.ExecuteNonQuery();

                return Ok(true);

            }
            else
            {
                return Ok(false);
            }
        }
        //funcion para login de usuario y valide su credenciales
        [ActionName("ValidarGerente")]
        [HttpGet]
        public IHttpActionResult ValidarGerente(string user, string contrasena)
        {
            DataTable tablaGerentes = new DataTable();
            List<GerenteApp> list = new List<GerenteApp>();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Region, Empresa_ID, Status from Gerentes where  NombreUsuario='" + user + "' and Contrasena='" + contrasena + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }
            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaGerentes);
                list = (from DataRow dr in tablaGerentes.Rows
                        select new GerenteApp()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Region = dr["Region"].ToString(),
                            Empresa_ID = Convert.ToInt32(dr["Empresa_ID"]),
                            Status = Convert.ToBoolean(dr["Status"])
                        }).ToList();
                cnc.Close();
                return Ok(list);
            }
            else
            {
                return null;
            }
        }

    }
    
}
