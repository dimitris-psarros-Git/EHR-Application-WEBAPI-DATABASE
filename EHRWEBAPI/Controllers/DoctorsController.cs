﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EHRWEBAPI.Models;

namespace EHRWEBAPI.Controllers
{
    public class DoctorsController : ApiController
    {
        private EHRsystemEntities db = new EHRsystemEntities();

        // GET: api/Doctors
        public IQueryable<Doctor> GetDoctors()
        {
            return db.Doctors;
        }

        [Route("api/FullNameDoctor/{Personid}")]
        [HttpGet]
        [ResponseType(typeof(FullNames))]
        public IQueryable<FullNames> GetFullName(int Personid)
        {
            var contactsList = from b in db.Doctors.
                            Where(c => (c.DoctorID == Personid))
                               select new FullNames()
                               {
                                   FirstName = b.FirstName,
                                   LastName = b.LastName
                               };
            return contactsList;
        }

        // GET: api/Doctors/5
        [ResponseType(typeof(Doctor))]
        public async Task<IHttpActionResult> GetDoctor(int id)
        {
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        // PUT: api/Doctors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctor.DoctorID)
            {
                return BadRequest();
            }

            db.Entry(doctor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctors
        [ResponseType(typeof(Doctor))]
        public async Task<IHttpActionResult> PostDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Doctors.Add(doctor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = doctor.DoctorID }, doctor);
        }

        // DELETE: api/Doctors/5
        [ResponseType(typeof(Doctor))]
        public async Task<IHttpActionResult> DeleteDoctor(int id)
        {
            Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            db.Doctors.Remove(doctor);
            await db.SaveChangesAsync();

            return Ok(doctor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorExists(int id)
        {
            return db.Doctors.Count(e => e.DoctorID == id) > 0;
        }
    }
}