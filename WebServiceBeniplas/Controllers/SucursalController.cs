﻿using beniplas.Model;
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
            AuthSecret = "EguwnkcfX8b28qSC8GPjX2rGQ3Bfa009ksx6B4YR",
            BasePath = "https://pusharduino-24bd1-default-rtdb.firebaseio.com/"
        };

        Model1 bd = new Model1();
        //funcion que inserta datos de una nueva sucursal a crear
        [ActionName("CargarDatosSucursal")]
        [HttpPost]
        public int CargarDatosSucursal(Sucursals Sucursal)
        {
            {
                var cajaID = new GuardaValores()
                {
                    CajaDerecha = false,
                    CajaIzquierda = false
                };
                var Cajas = new Cajas()
                {
                    Caja1 = false,
                    Caja2 = false,
                    Caja3 = false,
                    Caja4 = false
                };
                bool flag = false;
                SqlConnection cnc = new SqlConnection("Data Source=192.168.7.171;initial Catalog=Beniplas;User ID=sa;Password=&ccai$2022#");
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
                    SetResponse response1 = client.Set("Beniplas/" + Sucursal.Empresa + "/" + Sucursal.NumSucursal + "/" + cajaID.CajaDerecha, Cajas);
                    SetResponse response2 = client.Set("Beniplas/" + Sucursal.Empresa + "/" + Sucursal.NumSucursal + "/" + cajaID.CajaIzquierda, Cajas);
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