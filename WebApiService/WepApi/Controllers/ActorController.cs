using DAL;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WepApi.Controllers
{
    public class ActorController : ApiController
    {
        private PersonContext context = new PersonContext();

        // GET: api/actor
        public IEnumerable<Actor> Get()
        {
            return context.Actors.ToList();
        }

        // GET: api/actor/{id}
        public Actor Get(int id)
        {
            return context.Actors.Find(id);
        }

        // POST api/actor
        public HttpResponseMessage Post([FromBody]Actor actor)
        {
            if (actor.Id == 1 || actor.Id == 2)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            try { 
                context.Actors.Add(actor);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, actor);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        // PUT api/actor/{id}
        public HttpResponseMessage Put(int id, [FromBody]Actor actor)
        {
            if (id == 1 || id == 2)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            try
            {
                context.Actors.Attach(actor);
                context.Entry(actor).State = EntityState.Modified;
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, actor);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        // DELETE api/actor/{id}
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Actor actor = context.Actors.Find(id);
                context.Actors.Remove(actor);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, actor);
            }
            catch(Exception e) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}