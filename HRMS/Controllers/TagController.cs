using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRMS.Models;
using HRMS.Repository.DatabaseContext;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HRMS.Controllers
{
    public class TagController : ApiController
    {
        private HRMSContext db = new HRMSContext();

        // GET api/Tag
        public IEnumerable<Tag> GetTags()
        {
            return db.Tags.AsEnumerable();
        }

        // GET api/Tag/5
        public Tag GetTag(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tag;
        }

        // PUT api/Tag/5
        public HttpResponseMessage PutTag(int id, Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != tag.TagId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(tag).State = EntityState.Modified;

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

        // POST api/Tag
        public HttpResponseMessage PostTag(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tag);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tag.TagId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Tag/5
        public HttpResponseMessage DeleteTag(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Tags.Remove(tag);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tag);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
