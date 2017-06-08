using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI2_20170607.Models;

namespace WebAPI2_20170607.Controllers
{
    [RoutePrefix("Clients")]
    public class ClientsController : ApiController
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: api/Clients
        [Route("")]
        public IQueryable<Client> GetClient()
        {
            return db.Client;
        }

        // GET: api/Clients/5
        [Route("{id}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [Route("type2/{id}")]
        public Client GetClientType2(int id)
        {
            Client client = db.Client.Find(id);

            return client ;
        }

        [Route("type3/{id}")]
        public IHttpActionResult GetClientType3(int id)
        {
            Client client = db.Client.Find(id);

            return Json(client);
        }

        [Route("type4/{id}")]
        public HttpResponseMessage GetClientType4(int id)
        {
            Client client = db.Client.Find(id);

            return Request.CreateResponse(HttpStatusCode.OK,client);
        }

        [Route("type5/{id}")]
        public HttpResponseMessage GetClientType5(int id)
        {
            Client client = db.Client.Find(id);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent<Client>(client, GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
        }

        [Route("type6/{id}")]
        public HttpResponseMessage GetClientType6(int id)
        {
            Client client = db.Client.Find(id);

            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent<Client>(client, GlobalConfiguration.Configuration.Formatters.JsonFormatter),
                ReasonPhrase = "Hello World"
            };
            response.Headers.Add("aaaa", "bbb");
            return response;
        }

        // GET: api/Clients/5/Orders
        [Route("{id}/Orders")]
        public IHttpActionResult GetClientOrders(int id)
        {
            var Order = db.Order.Where(o => o.ClientId == id);
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }

        // GET: api/Clients/5/Orders
        [Route("{id}/Orders/{orderId:int}")]
        public IHttpActionResult GetClientOrders(int id,int orderId)
        {
            var Order = db.Order.Where(o => o.ClientId == id && o.OrderId == orderId);
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }

        [Route("~/api/clients/{id}/Orders/Pending")]
        public IHttpActionResult GetClientOrdersPending(int id)
        {
            var Order = db.Order.Where(o => o.ClientId == id && o.OrderStatus == "P");
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }

        [Route("{id}/Orders/{*date:datetime}")]
        public IHttpActionResult GetClientOrders(int id, DateTime date)
        {
            var Order = db.Order.Where(o => o.ClientId == id
            && o.OrderDate.Value.Year == date.Year
            && o.OrderDate.Value.Month == date.Month
                && o.OrderDate.Value.Day == date.Day);
            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Client.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Client.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Client.Count(e => e.ClientId == id) > 0;
        }
    }
}