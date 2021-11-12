using isolucion.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace isolucion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Ventas()
        {
            ViewBag.Message = "Facturacion";
            return View();
        }

        public ActionResult Clientes()
        {
            ViewBag.Message = "CRUD Clientes";

            return View();
        }

        public ActionResult Items()
        {
            ViewBag.Message = "CRUD Items";

            return View();
        }

        public async Task<JsonResult> GetClientes()
        {
            ApiControl api = new ApiControl();

            List<IDictionary<string, string>> listResult = new List<IDictionary<string, string>>();

            HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            //HttpResponseMessage response = await api.PostRequest(new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"), ServicesURL.GetClients);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    //listResult = JsonConvert.DeserializeObject<List<object>>(jsoncharge);
                    listResult = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(listResult, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> GetItems()
        {
            ApiControl api = new ApiControl();

            List<IDictionary<string, string>> listResult = new List<IDictionary<string, string>>();

            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.GetRequest(ServicesURL.GetItems);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    //listResult = JsonConvert.DeserializeObject<List<object>>(jsoncharge);
                    listResult = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(listResult, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> GetVentas()
        {
            ApiControl api = new ApiControl();

            List<IDictionary<string, string>> listResult = new List<IDictionary<string, string>>();

            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.GetRequest(ServicesURL.GetVentas);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    //listResult = JsonConvert.DeserializeObject<List<object>>(jsoncharge);
                    listResult = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(listResult, JsonRequestBehavior.AllowGet);

        }


        public async Task<JsonResult> GetVentasCli(int id)
        {
            ApiControl api = new ApiControl();

            List<IDictionary<string, string>> listResult = new List<IDictionary<string, string>>();
            HttpResponseMessage response = await api.PostRequest(
                new StringContent(JsonConvert.SerializeObject(
                    id), Encoding.UTF8, "application/json"), ServicesURL.GetVentasCli);
            

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    //listResult = JsonConvert.DeserializeObject<List<object>>(jsoncharge);
                    listResult = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(listResult, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> GetItemsFact(int factura)
        {
            ApiControl api = new ApiControl();

            List<IDictionary<string, string>> listResult = new List<IDictionary<string, string>>();

            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.PostRequest(new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json"), ServicesURL.GetItemsFact);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    //listResult = JsonConvert.DeserializeObject<List<object>>(jsoncharge);
                    listResult = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(listResult, JsonRequestBehavior.AllowGet);

        }
        
        
        public async Task<JsonResult> SetClient(Dictionary<string,string> cliente)
        {
            ApiControl api = new ApiControl();
            var msj = "";
            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.PostRequest(new StringContent(
                JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json"), ServicesURL.SetClient);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    msj = JsonConvert.DeserializeObject<string>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(msj, JsonRequestBehavior.AllowGet);

        }

        public async Task<JsonResult> DeleteClient(int id)
        {
            ApiControl api = new ApiControl();
            var msj = "";
            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.PostRequest(new StringContent(
                JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"), ServicesURL.DeleteClient);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    msj = JsonConvert.DeserializeObject<string>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(msj, JsonRequestBehavior.AllowGet);

        }


        public async Task<JsonResult> SetItem(Dictionary<string, string> item)
        {
            ApiControl api = new ApiControl();
            var msj = "";
            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.PostRequest(new StringContent(
                JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"), ServicesURL.SetItem);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    msj = JsonConvert.DeserializeObject<string>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(msj, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> DeleteItem(int id)
        {
            ApiControl api = new ApiControl();
            var msj = "";
            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.PostRequest(new StringContent(
                JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"), ServicesURL.DeleteItem);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    msj = JsonConvert.DeserializeObject<string>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(msj, JsonRequestBehavior.AllowGet);

        }


        public async Task<JsonResult> SetFactura(Dictionary<string, string> venta,List<Dictionary<string, string>> items)
        {
            ApiControl api = new ApiControl();
            var msj = "";
            //HttpResponseMessage response = await api.GetRequest(ServicesURL.GetClients);
            HttpResponseMessage response = await api.PostRequest(new StringContent(
                JsonConvert.SerializeObject(new { venta,items }), Encoding.UTF8, "application/json"), ServicesURL.SetFactura);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsoncharge = await response.Content.ReadAsStringAsync();
                    msj = JsonConvert.DeserializeObject<string>(jsoncharge);
                    break;
                default:
                    break;
            }
            return Json(msj, JsonRequestBehavior.AllowGet);
        }
    }
}