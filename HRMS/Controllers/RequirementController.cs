using HRMS.Models;
using HRMS.Repository.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRMS.Controllers
{
    public class RequirementController : ApiController
    {
        private HRMSContext db = new HRMSContext();

        // GET api/Requirement
        public IEnumerable<Requirement> GetRequirements()
        {
            return db.Requirements.AsEnumerable();
        }

        // GET api/Requirement/5
        public Requirement GetRequirement(int id)
        {
            Requirement requirement = db.Requirements.Find(id);
            if (requirement == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return requirement;
        }

        // PUT api/Requirement/5
        public HttpResponseMessage PutRequirement(int id, Requirement requirement)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != requirement.RequirementId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(requirement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Requirement
        public HttpResponseMessage PostRequirement(Requirement requirement)
        {
            if (ModelState.IsValid)
            {
                db.Requirements.Add(requirement);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, requirement);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = requirement.RequirementId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Requirement/5
        public HttpResponseMessage DeleteRequirement(int id)
        {
            Requirement requirement = db.Requirements.Find(id);
            if (requirement == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Requirements.Remove(requirement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, requirement);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
