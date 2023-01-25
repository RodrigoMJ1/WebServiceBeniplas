
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

        [ActionName("InsertarEmpleado")]
        [HttpPost]
        //funcion para cargar datos de un nuevo empleado
        public IHttpActionResult InsertarEmpleado(EmpleadoDTO empleado)
        {
            string noReg = "NoRegistrado";
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select *  from Empleadoes where NombreUsuario='" + empleado.NombreUsuario + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }
            if (flag == false)
            {
                rdr.Close();
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Empleadoes (NombreUsuario, Contraseña, Status, Sucursal_ID, Nombre, ApellidoP, ApellidoM, Correo, Codigo) VALUES(@NombreUsuario, @Contrasena, @Status, @Sucursal_ID, @Nombre, @ApellidoP, @ApellidoM, @Correo, @Codigo)", cnc);

                cmd2.Parameters.AddWithValue("@NombreUsuario", empleado.NombreUsuario);
                cmd2.Parameters.AddWithValue("@Contrasena", empleado.Contrasena);
                cmd2.Parameters.AddWithValue("@Status", empleado.Status);
                cmd2.Parameters.AddWithValue("@Sucursal_ID", empleado.Sucursal_ID);
                cmd2.Parameters.AddWithValue("@Nombre", noReg);
                cmd2.Parameters.AddWithValue("@ApellidoP", noReg);
                cmd2.Parameters.AddWithValue("@ApellidoM", noReg);
                cmd2.Parameters.AddWithValue("@Correo", noReg);
                cmd2.Parameters.AddWithValue("@Codigo", noReg);
                cmd2.ExecuteNonQuery();
                return Ok(true);

            }
            else
            {
                return Ok(false);
            }
        }
        //funcion para retornar una lista de empleados en torno a una sucursal
        [ActionName("CargarDatosEmpleado")]
        [HttpGet]
        public dynamic CargarDatosEmpleado(int idSucursal)
        {
            List<EmpleadoDTO2> list = new List<EmpleadoDTO2>();
            DataTable tablaEmpleados = new DataTable();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre, ApellidoP, ApellidoM, Correo, Status  from Empleadoes where Sucursal_ID='" + idSucursal + "'", cnc);
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
                        select new EmpleadoDTO2()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApellidoP = dr["ApellidoP"].ToString(),
                            ApellidoM = dr["ApellidoM"].ToString(),
                            Correo = Convert.ToString(dr["Correo"].ToString()),
                            Status = bool.Parse(dr["Status"].ToString())
                        }).ToList();
            }
            cnc.Close();
            return Ok(list);
        }
        //funcion para actualizar solamente el status del gerente en base a us id y su status que tiene actualmente
        [ActionName("ActualizarStatusEmpleado")]
        [HttpGet]

        public IHttpActionResult ActualizarStatusEmpleado(int id, bool status)
        {
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select Status from Empleadoes where ID='" + id + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                rdr.Close();
                SqlCommand cmd2 = new SqlCommand("UPDATE Empleadoes SET[Status] = @Status where ID='" + id + "'", cnc);
                if (status == true)
                {
                    status = false;
                    cmd2.Parameters.AddWithValue("@Status", status);
                    cmd2.ExecuteNonQuery();
                    return Ok("Empleado desactivado");
                }
                else
                {
                    status = true;
                    cmd2.Parameters.AddWithValue("@status", status);
                    cmd2.ExecuteNonQuery();
                    return Ok("Empleado activado");
                }
            }
            else
            {
                return Ok("Empleado no encontrado");
            }
        }
        //funcion para cargar los datos faltantes de el empleado, esto mediante la app movil
        [ActionName("ActualizarDatos")]
        [HttpPut]
        public dynamic ActualizarDatos(Empleado empleado)
        {
            bool flag = true;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Empleadoes SET [Nombre] = @nombre , [ApellidoP] = @apellidoPa , [ApellidoM] = @apellidoMa , [Correo] = @Correo , [Codigo] = @codigo , [Contraseña] = @contra  where NombreUsuario='" + empleado.NombreUsuario + "'", cnc);
            cmd.Parameters.AddWithValue("@nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("@apellidoPa", empleado.ApellidoP);
            cmd.Parameters.AddWithValue("@apellidoMa", empleado.ApellidoM);
            cmd.Parameters.AddWithValue("@Correo", empleado.Correo);
            cmd.Parameters.AddWithValue("@codigo", empleado.Codigo);
            cmd.Parameters.AddWithValue("@contra", empleado.Contrasena);
            cmd.ExecuteNonQuery();
            return flag;
        }

        //funcion para cargar los datos faltantes de el empleado, esto mediante la app movil
        [ActionName("ActualizarContrasena")]
        [HttpGet]
        public bool ActualizarContrasena(string user, string contrasena)
        {
            bool flag = true;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Empleadoes SET [Contraseña] = @contra  where NombreUsuario='" + user + "'", cnc);
            cmd.Parameters.AddWithValue("@contra", contrasena);
            cmd.ExecuteNonQuery();
            return flag;
        }
        //funcion para hacer el login del empleado y validar las credenciales
        [ActionName("ValidarEmpleado")]
        [HttpGet]
        public IHttpActionResult ValidarEmpleado(string user, string contrasena)
        {
            DataTable tablaEmpleado = new DataTable();
            List<EmpleadoDTO> list = new List<EmpleadoDTO>();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Status, Sucursal_ID, Correo, NombreUsuario, Codigo from Empleadoes where  NombreUsuario='" + user + "' and Contraseña='" + contrasena + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }
            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaEmpleado);
                list = (from DataRow dr in tablaEmpleado.Rows
                        select new EmpleadoDTO()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            NombreUsuario = Convert.ToString(dr["NombreUsuario"]),
                            Sucursal_ID = Convert.ToInt32(dr["Sucursal_ID"]),
                            Status = Convert.ToBoolean(dr["Status"]),
                            Correo = Convert.ToString(dr["Correo"]),
                            Codigo = Convert.ToString(dr["Codigo"])
                        }).ToList();
                cnc.Close();
                return Ok(list);
            }
            else
            {
                return Ok("No");
            }
        }

        //funcion para hacer el logim del empleado y validar las credenciales
        [ActionName("EnviarCodigo")]
        [HttpGet]
        public IHttpActionResult EnviarCodigo(string user)
        {
            DataTable tablaEmpleado = new DataTable();
            List<EmpleadoDTO> list = new List<EmpleadoDTO>();
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=sql8004.site4now.net ;initial Catalog=db_a936a9_betabeniplas;User ID=db_a936a9_betabeniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select Correo from Empleadoes where  NombreUsuario='" + user + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }
            if (flag == true)
            {
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(tablaEmpleado);
                list = (from DataRow dr in tablaEmpleado.Rows
                        select new EmpleadoDTO()
                        {
                            Correo = Convert.ToString(dr["Correo"])
                        }).ToList();
                cnc.Close();
                return Ok(list);
            }
            else
            {
                return Ok("No");
            }
        }
    }
}
