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

        [ActionName("InsertarEmpleado")]
        [HttpPost]
        //funcion para cargar datos de un nuevo empleado
        public IHttpActionResult InsertarEmpleado(EmpleadoDTO empleado)
        {
            string noReg = "NoRegistrado";
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
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
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Empleadoes (NombreUsuario, Contrasena, Status, Sucursal_ID, Nombre, ApellidoP, ApellidoM, NumTel) VALUES(@NombreUsuario, @Contrasena, @Status, @Sucursal_ID, @Nombre, @ApellidoP, @ApellidoM, @NumTel)", cnc);

                cmd2.Parameters.AddWithValue("@NombreUsuario", empleado.NombreUsuario);
                cmd2.Parameters.AddWithValue("@Contrasena", empleado.Contrasena);
                cmd2.Parameters.AddWithValue("@Status", empleado.Status);
                cmd2.Parameters.AddWithValue("@Sucursal_ID", empleado.Sucursal_ID);
                cmd2.Parameters.AddWithValue("@Nombre", noReg);
                cmd2.Parameters.AddWithValue("@ApellidoP", noReg);
                cmd2.Parameters.AddWithValue("@ApellidoM", noReg);
                cmd2.Parameters.AddWithValue("@NumTel", 0);
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
                        select new EmpleadoDTO2()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),
                            ApellidoP = dr["ApellidoP"].ToString(),
                            ApellidoM = dr["ApellidoM"].ToString(),
                            NumTel = long.Parse(dr["NumTel"].ToString()),
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
        //funcion para cargar los datos faltantes de el empleado, esto mediante la app movil
        [ActionName("ActualizarDatos")]
        [HttpPut]
        public dynamic ActualizarDatos(Empleado empleado, int id)
        {
            bool flag = true;
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Empleadoes SET [Nombre] = @nombre, [ApellidoP] = @apellidoPa, [ApellidoM] = @apellidoMa, [NumTel] = @numT, [Codigo] = @codigo, [Contrasena] = @contra  where ID='" + id + "'", cnc);
            cmd.Parameters.AddWithValue("@nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("@apellidoPa", empleado.ApellidoP);
            cmd.Parameters.AddWithValue("@apellidoMa", empleado.ApellidoM);
            cmd.Parameters.AddWithValue("@numT", empleado.NumTel);
            cmd.Parameters.AddWithValue("@codigo", empleado.Codigo);
            cmd.Parameters.AddWithValue("@contra", empleado.Contrasena);
            cmd.ExecuteNonQuery();
            return flag;
        }

        //funcion para hacer el logim del empleado y validar las credenciales
        [ActionName("ValidarEmpleado")]
        [HttpGet]
        public bool ValidarEmpleado(string user, string contrasena)
        {
            bool flag = false;
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select NombreUsuario, Contrasena from Empleadoes where  NombreUsuario='" + user + "' and Contrasena='" + contrasena + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }
            if (flag == true)
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
