using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRMS.Repository.DatabaseContext;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HRMS.Controllers
{
    public class JobController : ApiController
    {
        private HRMSContext db = new HRMSContext();

        // GET api/Job
        [HttpGet]
        public IEnumerable<Job> GetJobs()
        {
            return db.Jobs.AsEnumerable();
        }

        // GET api/Job/5
        [HttpGet]
        public Job GetJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return job;
        }

        // PUT api/Job/5
        public HttpResponseMessage PutJob(int id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != job.JobId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(job).State = EntityState.Modified;

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

        // POST api/Job
        public HttpResponseMessage PostJob(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, job);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = job.JobId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Job/5
        public HttpResponseMessage DeleteJob(int id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Jobs.Remove(job);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, job);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
