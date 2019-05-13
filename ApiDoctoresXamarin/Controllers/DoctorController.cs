using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDoctoresXamarin.Models;
using ApiDoctoresXamarin.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDoctoresXamarin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        RepositoryDoctor repo;
        public DoctorController(RepositoryDoctor repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public List<Doctor> Get()
        {
            return repo.GetDoctor();
        }
        [HttpGet("{id}", Name = "Get")]
        public Doctor Get(int id)
        {
            return repo.GetDoctor(id);
        }
        [HttpPost]
        public void Post(Doctor doc)
        {
            repo.InsertDoctor(doc.LastName, doc.Speciality, doc.Salary, doc.Hospital);
        }
        [HttpPut("{id}")]
        public void Put(int id, Doctor doc)
        {
            repo.UpdateDoctor(id, doc.LastName, doc.Speciality, doc.Salary, doc.Hospital);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.DeleteDoctor(id);
        }
    }
}