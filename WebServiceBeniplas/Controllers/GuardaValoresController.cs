using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebServiceBeniplas.Models;

namespace WebServiceBeniplas.Controllers
{
    public class GuardaValoresController : ApiController
    {
        IFirebaseClient client;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "9ddLJOZSfNACR4MgN4teiDzaQuRM4MCgIOPAcE4W",
            BasePath = "https://beniplas-97420-default-rtdb.firebaseio.com/"
        };
        [ActionName("AbrirPuertaD")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaD(GuardaValoresSucursal info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/PuertaDerecha");
            if (bool.Parse(response.Body) == false)
            {
                info.PuertaDerecha = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/PuertaDerecha", info.PuertaDerecha);
                return Ok("Puerta Derecha Abierta");
            }
            else
            {
                return Ok("Puerta derecha ya fue abierta");
            }
        }

        [ActionName("AbrirPuertaD1")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaD1(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja1D");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja1D = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja1D", info.Caja1D);
                return Ok("Caja1 Abierta");
            }
            else
            {
                return Ok("Caja1 ya fue abierta");
            }
        }
        [ActionName("AbrirPuertaD2")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaD2(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja2D");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja2D = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja2D", info.Caja2D);
                return Ok("Caja2 Abierta");
            }
            else
            {
                return Ok("Caja2 ya fue abierta");
            }
        }

        [ActionName("AbrirPuertaD3")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaD3(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja3D");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja3D = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja3D", info.Caja3D);
                return Ok("Caja3 Abierta");
            }
            else
            {
                return Ok("Caja3 ya fue abierta");
            }
        }

        [ActionName("AbrirPuertaD4")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaD4(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja4D");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja4D = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja4D", info.Caja4D);
                return Ok("Caja4 Abierta");
            }
            else
            {
                return Ok("Caja4 ya fue abierta");
            }
        }

        [ActionName("AbrirPuertaI")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaI(GuardaValoresSucursal info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/PuertaIzquierda");
            if (bool.Parse(response.Body) == false)
            { 
                info.PuertaIzquierda = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/PuertaIzquierda", info.PuertaIzquierda);
                return Ok("Puerta Izquierda Abierta");
            }
            else
            {
                return Ok("Puerta izquierda ya fue abierta");
            }
        }

        [ActionName("AbrirPuertaI1")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaI1(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja1I");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja1I = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja1I", info.Caja1I);
                return Ok("Caja1 Abierta");
            }
            else
            {
                return Ok("Caja1 ya fue abierta");
            }
        }
        [ActionName("AbrirPuertaI2")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaI2(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja2I");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja2I = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja2I", info.Caja2I);
                return Ok("Caja2 Abierta");
            }
            else
            {
                return Ok("Caja2 ya fue abierta");
            }
        }

        [ActionName("AbrirPuertaI3")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaI3(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja3I");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja3I = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja3I", info.Caja3I);
                return Ok("Caja3 Abierta");
            }
            else
            {
                return Ok("Caja3 ya fue abierta");
            }
        }

        [ActionName("AbrirPuertaI4")]
        [HttpPost]
        public IHttpActionResult AbrirPuertaI4(GuardaValores info)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja4I");
            if (bool.Parse(response.Body) == false)
            {
                info.Caja4I = true;
                SetResponse response1 = client.Set("Beniplas/" + info.Empresa + "/" + info.NumSucursal + "/Caja4I", info.Caja4I);
                return Ok("Caja4 Abierta");
            }
            else
            {
                return Ok("Caja4 ya fue abierta");
            }
        }
    }
}
