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
            List<EmpresaDTO> listaEmpresas = new List<EmpresaDTO>();
            listaEmpresas = (from em in bd.Empresas
                             select new EmpresaDTO
                             {
                                 ID = em.ID,
                                 Nombre = em.Nombre,
                             }).ToList();
            return Ok(listaEmpresas);
        }

        [ActionName("ListRegiones")]
        [HttpGet]
        //funcion para retornar informacion de regiones en forma de lista en base a una empresa
        public IHttpActionResult ListRegiones(int id)
        {
            List<String> listaRegions = new List<String>();
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
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
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
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

        [ActionName("ListGerente")]
        [HttpGet]
        //función para retornar una lista de gerentes en torno a una empresa
        public IHttpActionResult ListGerente(int empresaID)
        {
            bool flag = false;
            List<GerenteDTO2> listSucursal = new List<GerenteDTO2>();
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
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

    }
}
