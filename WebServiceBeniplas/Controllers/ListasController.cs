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
    public class ListasController : ApiController
    {
        Model1 bd = new Model1();

        [ActionName("ListEmpresa")]
        [HttpGet]
        //funcion para retornar informacion de empresas en forma de lista
        public IHttpActionResult ListEmpresa()
        {
            bool flag = false;
            List<EmpresaDTO> empresas = new List<EmpresaDTO>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre from Empresas", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                empresas = (from DataRow da in dt.Rows
                                select new EmpresaDTO()
                                {
                                    ID = Convert.ToInt32(da["ID"]),
                                    Nombre = da["Nombre"].ToString(),
                                }).ToList();
                cnc.Close();
                return Ok(empresas);
            }
            else
            {
                return null;
            }
        }

        [ActionName("ListRegiones")]
        [HttpGet]
        //funcion para retornar informacion de regiones en forma de lista en base a una empresa
        public IHttpActionResult ListRegiones(int id)
        {
            List<String> listaRegions = new List<String>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select DISTINCT(Region) from Gerentes where Empresa_ID=" + id, cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                listaRegions.Add(rdr[0].ToString());
            }
            cnc.Close();
            return Ok(listaRegions);
        }

        [ActionName("ListSucursal_Empresa")]
        [HttpGet]
        //funcion para retornar informacion en forma de lista en base a una empresa, la cual primero sera convertida en una tabla para ser pasada a una lista
        public IHttpActionResult ListSucursal_Empresa(int empresaID)
        {
            bool flag = false;
            List<Sucursals> listSucursal = new List<Sucursals>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Empresa_ID, NumSucursal  from Sucursals where Empresa_ID='" + empresaID + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                listSucursal = (from DataRow da in dt.Rows
                                select new Sucursals()
                                {
                                    ID = Convert.ToInt32(da["ID"]),
                                    Empresa_ID = Convert.ToInt32(da["Empresa_ID"]),
                                    NumSucursal = Convert.ToInt32(da["NumSucursal"]),
                                }).ToList();
                cnc.Close();
                return Ok(listSucursal);
            }
            else
            {
                return null;
            }
        }

        [ActionName("ListSucursal_Gerente")]
        [HttpGet]
        //funcion para retornar informacion en forma de lista en base a una empresa y gerente, la cual primero sera convertida en una tabla para ser pasada a una lista
        public IHttpActionResult ListSucursal_Gerente(int empresaID, int gerenteID)
        {
            bool flag = false;
            List<Sucursals2> listSucursal = new List<Sucursals2>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, NumSucursal from Sucursals where Empresa_ID='" + empresaID + "' and Gerente_ID='" + gerenteID + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true; 

            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                listSucursal = (from DataRow da in dt.Rows
                                select new Sucursals2()
                                {
                                    ID = Convert.ToInt32(da["ID"]),
                                    NumSucursal = Convert.ToInt32(da["NumSucursal"])
                                }).ToList();    
                cnc.Close();
                return Ok(listSucursal);
            }
            else
            {
                return null;
            }
        }
        [ActionName("ListGerente")]
        [HttpGet]
        //función para retornar una lista de gerentes en torno a una empresa
        public IHttpActionResult ListGerente(int empresaID)
        {
            bool flag = false;
            List<GerenteDTO2> listSucursal = new List<GerenteDTO2>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Empresa_ID, Nombre  from Gerentes where Empresa_ID='" + empresaID + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                listSucursal = (from DataRow da in dt.Rows
                                select new GerenteDTO2()
                                {
                                    ID = Convert.ToInt32(da["ID"]),
                                    Nombre = da["Nombre"].ToString(),
                                }).ToList();
                cnc.Close();
                return Ok(listSucursal);
            }
            else
            {
                return null;
            }
        }
        [ActionName("ListAdmin")]
        [HttpGet]
        //función para retornar una lista de gerentes en torno a una empresa
        public IHttpActionResult ListAdmin()
        {
            bool flag = false;
            List<Administrador> Administradores = new List<Administrador>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre from Administradors", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                Administradores = (from DataRow da in dt.Rows
                                 select new Administrador()
                                 {
                                     ID = Convert.ToInt32(da["ID"]),
                                     Nombre = da["Nombre"].ToString(),
                                 }).ToList();
                cnc.Close();
                return Ok(Administradores);
            }
            else
            {
                return null;
            }
        }
        [ActionName("ListEmpleado")]
        [HttpGet]
        //función para retornar una lista de gerentes en torno a una empresa
        public IHttpActionResult ListEmpleado(int sucursalID)
        {
            bool flag = false;
            List<EmpleadoDTO> listEmpleados = new List<EmpleadoDTO>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select ID, Nombre  from Empleadoes where Sucursal_ID='" + sucursalID + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                listEmpleados = (from DataRow da in dt.Rows
                                select new EmpleadoDTO()
                                {
                                    ID = Convert.ToInt32(da["ID"]),
                                    Nombre = da["Nombre"].ToString(),
                                }).ToList();
                cnc.Close();
                return Ok(listEmpleados);
            }
            else
            {
                return null;
            }
        }

        [ActionName("ListaFecha_Admin")]
        [HttpGet]
        //función para retornar una lista de gerentes en torno a una empresa
        public IHttpActionResult ListaFecha_Admin(int sucursalID, int empresaID, int administradorID)
        {
            bool flag = false;
            List<RegistroAperturaAdministradorDTO> listfecha = new List<RegistroAperturaAdministradorDTO>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select Año, Mes from RegistroAperturaAdministradors where Sucursal_ID='" + sucursalID + "' and Empresa_ID='" +empresaID + "' and Administrador_ID='" + administradorID + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                listfecha = (from DataRow da in dt.Rows
                                 select new RegistroAperturaAdministradorDTO()
                                 {
                                     Año = da["Año"].ToString(),
                                     Mes = da["Mes"].ToString(),
                                 }).ToList();
                cnc.Close();
                return Ok(listfecha);
            }
            else
            {
                return null;
            }
        }

        [ActionName("ListaFecha_Gerente")]
        [HttpGet]
        //función para retornar una lista de gerentes en torno a una empresa
        public IHttpActionResult ListaFecha_Gerente(int empresaID, int gerenteID)
        {
            bool flag = false;
            List<RegistroAperturaGerenteDTO> listfecha = new List<RegistroAperturaGerenteDTO>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select Año, Mes from RegistroAperturaGerentes where Empresa_ID='" + empresaID + "' and Gerente_ID='" + gerenteID + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                listfecha = (from DataRow da in dt.Rows
                             select new RegistroAperturaGerenteDTO()
                             {
                                 Año = da["Año"].ToString(),
                                 Mes = da["Mes"].ToString(),
                             }).ToList();
                cnc.Close();
                return Ok(listfecha);
            }
            else
            {
                return null;
            }
        }

        [ActionName("ListaFecha_Empleado")]
        [HttpGet]
        public IHttpActionResult ListaFecha_Empleado(int sucursalID, int empleadoID)
        {
            bool flag = false;
            List<RegistroAperturaEmpleadoDTO> listfecha = new List<RegistroAperturaEmpleadoDTO>();
            SqlConnection cnc = new SqlConnection("Data Source=sql5104.site4now.net;initial Catalog=db_a8e73b_beniplas;User ID=db_a8e73b_beniplas_admin;Password=Daniel05");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select Año, Mes from RegistroAperturaEmpleadoes where Sucursal_ID='" + sucursalID + "' and Empleado_ID='" + empleadoID + "'", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                flag = true;
            }

            if (flag == true)
            {
                DataTable dt = new DataTable();
                rdr.Close();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(dt);
                listfecha = (from DataRow da in dt.Rows
                             select new RegistroAperturaEmpleadoDTO()
                             {
                                 Año = da["Año"].ToString(),
                                 Mes = da["Mes"].ToString(),
                             }).ToList();
                cnc.Close();
                return Ok(listfecha);
            }
            else
            {
                return null;
            }
        }
    }
}
