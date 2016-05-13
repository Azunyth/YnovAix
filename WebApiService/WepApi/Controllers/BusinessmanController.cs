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
    public class BusinessmanController : ApiController
    {
        private PersonContext context = new PersonContext();

        // GET: api/businessman
        public IEnumerable<BusinessMan> Get()
        {
            return context.BusinessMans.ToList();
        }

        // GET: api/businessman/{id}
        public BusinessMan Get(int id)
        {
            return context.BusinessMans.Find(id);
        }

        // POST api/businessman
        public HttpResponseMessage Post([FromBody]BusinessMan businessMan)
        {
            try { 
                context.BusinessMans.Add(businessMan);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, businessMan);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        // PUT api/businessman/{id}
        public HttpResponseMessage Put(int id, [FromBody]BusinessMan businessMan)
        {
            if (businessMan.Id == 3 || businessMan.Id == 4)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            try { 
                context.BusinessMans.Attach(businessMan);
                context.Entry(businessMan).State = EntityState.Modified;
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, businessMan);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
}

        // DELETE api/businessman/{id}
        public HttpResponseMessage Delete(int id)
        {
            if(id == 3 || id == 4)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden);
            }
            try { 
                BusinessMan businessMan = context.BusinessMans.Find(id);
                context.BusinessMans.Remove(businessMan);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, businessMan);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
}
    }
}