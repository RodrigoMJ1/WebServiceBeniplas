using beniplas.Model;
using System;
using System.Collections.Generic;
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
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO RegistroAperturaAdministradors (Comentario, FechaHora, Administrador_ID) VALUES(@Comentario, @FechaHora, @Administrador_ID)", cnc);

            cmd2.Parameters.AddWithValue("@Comentario", registroAperturaAdministrador.Comentario);
            cmd2.Parameters.AddWithValue("@FechaHora", registroAperturaAdministrador.FechaHora);
            cmd2.Parameters.AddWithValue("@Administrador_ID", registroAperturaAdministrador.Administrador_ID);
            cmd2.ExecuteNonQuery();
            return Ok(true);
        }

        [ActionName("InsertarRegistroAperturaGerente")]
        [HttpPost]
        ////funcion para insertar un nuevo registro de apertura de un gerente
        public IHttpActionResult InsertarRegistroAperturaGerente(RegistroAperturaGerenteDTO registroAperturaGerente)
        {
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO RegistroAperturaGerentes (Comentario, FechaHora, Gerente_ID) VALUES(@Comentario, @FechaHora, @Gerente_ID)", cnc);

            cmd2.Parameters.AddWithValue("@Comentario", registroAperturaGerente.Comentario);
            cmd2.Parameters.AddWithValue("@FechaHora", registroAperturaGerente.FechaHora);
            cmd2.Parameters.AddWithValue("@Gerente_ID", registroAperturaGerente.Gerente_ID);
            cmd2.ExecuteNonQuery();
            return Ok(true);
        }

        [ActionName("InsertarRegistroAperturaEmpleado")]
        [HttpPost]
        //funcion para insertar un nuevo registro de apertura de un empleado
        public IHttpActionResult InsertarRegistroAperturaEmpleado(RegistroAperturaEmpleadoDTO registroAperturaEmpleado)
        {
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
            cnc.Open();
            SqlCommand cmd2 = new SqlCommand("INSERT INTO RegistroAperturaEmpleadoes (Comentario, FechaHora, Empleado_ID) VALUES(@Comentario, @FechaHora, @Empleado_ID)", cnc);

            cmd2.Parameters.AddWithValue("@Comentario", registroAperturaEmpleado.Comentario);
            cmd2.Parameters.AddWithValue("@FechaHora", registroAperturaEmpleado.FechaHora);
            cmd2.Parameters.AddWithValue("@Empleado_ID", registroAperturaEmpleado.Empleado_ID);
            cmd2.ExecuteNonQuery();
            return Ok(true);
        }
    }
}
