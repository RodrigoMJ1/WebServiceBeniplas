using beniplas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceBeniplas.Controllers
{
    public class RegistroAperturaController : ApiController
    {
        [ActionName("InsertarRegistroAperturaAdmin")]
        [HttpPost]
        //funcion para insertar un nuevo registro de apertura de un adiministrador
        public IHttpActionResult InsertarRegistroAperturaAdmin(RegistroAperturaAdministradorDTO registroAperturaAdministrador)
        {
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO RegistroAperturaAdministradors (Comentario, Año, Mes, Dia, Hora, Administrador_ID, Empresa_ID, Sucursal_ID) VALUES(@Comentario, @Año ,@Mes ,@Dia , @Hora, @Administrador_ID, @Empresa_ID, @Sucursal_ID)", cnc);

            cmd2.Parameters.AddWithValue("@Comentario", registroAperturaAdministrador.Comentario);
            cmd2.Parameters.AddWithValue("@Año", registroAperturaAdministrador.Año);
            cmd2.Parameters.AddWithValue("@Mes", registroAperturaAdministrador.Mes);
            cmd2.Parameters.AddWithValue("@Dia", registroAperturaAdministrador.Dia);
            cmd2.Parameters.AddWithValue("@Hora", registroAperturaAdministrador.Hora);
            cmd2.Parameters.AddWithValue("@Administrador_ID", registroAperturaAdministrador.Administrador_ID);
            cmd2.Parameters.AddWithValue("@Empresa_ID", registroAperturaAdministrador.Empresa_ID);
            cmd2.Parameters.AddWithValue("@Sucursal_ID", registroAperturaAdministrador.Sucursal_ID);
            cmd2.ExecuteNonQuery();
            return Ok(true);
        }

        //funcion para retornar una lista de empleados en torno a una sucursal
        [ActionName("CargaRegistroAperturaAdmin")]
        [HttpGet]
        public dynamic CargaRegistroAperturaAdmin(int sucursalID, int empresaID, int administradorID, string año, string mes)
        {
            List<RegistroAperturaAdministradorDTO> list = new List<RegistroAperturaAdministradorDTO>();
            DataTable tablaRegistroAperturaAdmin = new DataTable();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Comentario, Año, Mes, Dia, Hora, Administrador_ID from RegistroAperturaAdministradors where Sucursal_ID='" + sucursalID + "' and Empresa_ID='" + empresaID + "' and Administrador_ID='" + administradorID + "' and Año='" + año + "' and Mes='" + mes + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaRegistroAperturaAdmin);

                list = (from DataRow dr in tablaRegistroAperturaAdmin.Rows
                        select new RegistroAperturaAdministradorDTO()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Comentario = dr["Comentario"].ToString(),
                            Año = dr["Año"].ToString(),
                            Mes = dr["Mes"].ToString(),
                            Dia = dr["Dia"].ToString(),
                            Hora = dr["Hora"].ToString(),
                            Administrador_ID = Convert.ToInt32(dr["Administrador_ID"]),
                        }).ToList();
            }
            cnc.Close();
            return Ok(list);
        }

        [ActionName("InsertarRegistroAperturaGerente")]
        [HttpPost]
        ////funcion para insertar un nuevo registro de apertura de un gerente
        public IHttpActionResult InsertarRegistroAperturaGerente(RegistroAperturaGerenteDTO registroAperturaGerente)
        {
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO RegistroAperturaGerentes (Comentario, Año, Mes, Dia, Hora, Gerente_ID, Empresa_ID) VALUES(@Comentario, @Año ,@Mes ,@Dia , @Hora, @Gerente_ID, @Empresa_ID)", cnc);

            cmd2.Parameters.AddWithValue("@Comentario", registroAperturaGerente.Comentario);
            cmd2.Parameters.AddWithValue("@Año", registroAperturaGerente.Año);
            cmd2.Parameters.AddWithValue("@Mes", registroAperturaGerente.Mes);
            cmd2.Parameters.AddWithValue("@Dia", registroAperturaGerente.Dia);
            cmd2.Parameters.AddWithValue("@Hora", registroAperturaGerente.Hora);
            cmd2.Parameters.AddWithValue("@Gerente_ID", registroAperturaGerente.Gerente_ID);
            cmd2.Parameters.AddWithValue("@Empresa_ID", registroAperturaGerente.Empresa_ID);
            cmd2.ExecuteNonQuery();
            return Ok(true);
        }
        [ActionName("CargaRegistroAperturaGerentes")]
        [HttpGet]
        public dynamic CargaRegistroAperturaGerentes(int empresaID, int gerenteID, string año, string mes)
        {
            List<RegistroAperturaGerenteDTO> list = new List<RegistroAperturaGerenteDTO>();
            DataTable tablaRegistroAperturaGerente = new DataTable();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Comentario, Año, Mes, Dia, Hora, Gerente_ID from RegistroAperturaGerentes where Empresa_ID='" + empresaID + "' and Gerente_ID='" + gerenteID + "' and Año='" + año + "' and Mes='" + mes + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaRegistroAperturaGerente);

                list = (from DataRow dr in tablaRegistroAperturaGerente.Rows
                        select new RegistroAperturaGerenteDTO()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Comentario = dr["Comentario"].ToString(),
                            Año = dr["Año"].ToString(),
                            Mes = dr["Mes"].ToString(),
                            Dia = dr["Dia"].ToString(),
                            Hora = dr["Hora"].ToString(),
                            Gerente_ID = Convert.ToInt32(dr["Gerente_ID"]),
                        }).ToList();
            }
            cnc.Close();
            return Ok(list);
        }
        [ActionName("InsertarRegistroAperturaEmpleado")]
        [HttpPost]
        //funcion para insertar un nuevo registro de apertura de un empleado
        public IHttpActionResult InsertarRegistroAperturaEmpleado(RegistroAperturaEmpleadoDTO registroAperturaEmpleado)
        {
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO RegistroAperturaEmpleadoes (Comentario, Año, Mes, Dia, Hora, Empleado_ID, Sucursal_ID) VALUES(@Comentario, @Año ,@Mes ,@Dia , @Hora, @Empleado_ID, @Sucursal_ID)", cnc);

            cmd2.Parameters.AddWithValue("@Comentario", registroAperturaEmpleado.Comentario);
            cmd2.Parameters.AddWithValue("@Año", registroAperturaEmpleado.Año);
            cmd2.Parameters.AddWithValue("@Mes", registroAperturaEmpleado.Mes);
            cmd2.Parameters.AddWithValue("@Dia", registroAperturaEmpleado.Dia);
            cmd2.Parameters.AddWithValue("@Hora", registroAperturaEmpleado.Hora);
            cmd2.Parameters.AddWithValue("@Empleado_ID", registroAperturaEmpleado.Empleado_ID);
            cmd2.Parameters.AddWithValue("@Sucursal_ID", registroAperturaEmpleado.Sucursal_ID);
            cmd2.ExecuteNonQuery();
            return Ok(true);
        }
        //funcion para retornar una lista de empleados en torno a una sucursal
        [ActionName("CargaRegistroAperturaEmpleados")]
        [HttpGet]
        public dynamic CargaRegistroAperturaEmpleados(int sucursalID, int empleadoID, string año, string mes)
        {
            List<RegistroAperturaEmpleadoDTO> list = new List<RegistroAperturaEmpleadoDTO>();
            DataTable tablaRegistroAperturaEmpleado = new DataTable();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Comentario, Año, Mes, Dia, Hora, Empleado_ID from RegistroAperturaEmpleadoes where Sucursal_ID='" + sucursalID + "' and Empleado_ID='" + empleadoID + "' and Año='" + año + "' and Mes='" + mes + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaRegistroAperturaEmpleado);

                list = (from DataRow dr in tablaRegistroAperturaEmpleado.Rows
                        select new RegistroAperturaEmpleadoDTO()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Comentario = dr["Comentario"].ToString(),
                            Año = dr["Año"].ToString(),
                            Mes = dr["Mes"].ToString(),
                            Dia = dr["Dia"].ToString(),
                            Hora = dr["Hora"].ToString(),
                            Empleado_ID = Convert.ToInt32(dr["Empleado_ID"]),
                        }).ToList();
            }
            cnc.Close();
            return Ok(list);
        }
    }
}
