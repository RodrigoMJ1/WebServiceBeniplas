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

        public IHttpActionResult ListRegiones()
        {
            List<String> listaRegions = new List<String>();
            SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select DISTINCT(Region) from Gerentes", cnc);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                listaRegions.Add(rdr[0].ToString());
            }
            cnc.Close();
            return Ok(listaRegions);
        }

        [ActionName("ListSucursal")]
        [HttpGet]

        public IHttpActionResult ListSucursal(int empresaID)
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

    }
}
