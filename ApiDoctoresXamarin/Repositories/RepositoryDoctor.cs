using ApiDoctoresXamarin.Data;
using ApiDoctoresXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDoctoresXamarin.Repositories
{
    public class RepositoryDoctor
    {
        HospitalContext context;
        public RepositoryDoctor(HospitalContext context)
        {
            this.context = context;
        }
        public List<Doctor> GetDoctor()
        {
            return context.Doctors.ToList();
        }
        public Doctor GetDoctor(int id)
        {
            return context.Doctors.SingleOrDefault(z => z.Id.Equals(id));
        }
        private int GetMaxIdDoctor()
        {
            return context.Doctors.Max(z => z.Id);
        }
        public void InsertDoctor(String lastname, String speciality, int salary, int hospital)
        {
            Doctor newDoctor = new Doctor()
            {
                Id = GetMaxIdDoctor() + 1,
                LastName = lastname,
                Speciality = speciality,
                Salary = salary,
                Hospital = hospital
            };
            context.Doctors.Add(newDoctor);
            context.SaveChanges();
        }
        public void UpdateDoctor(int id, String lastname, String speciality, int salary, int hospital)
        {
            Doctor doc = GetDoctor(id);
            doc.LastName = lastname;
            doc.Speciality = speciality;
            doc.Salary = salary;
            doc.Hospital = hospital;
            context.SaveChanges();
        }
        public void DeleteDoctor(int id)
        {
            Doctor doc = GetDoctor(id);
            context.Doctors.Remove(doc);
            context.SaveChanges();
        }
    }
}
