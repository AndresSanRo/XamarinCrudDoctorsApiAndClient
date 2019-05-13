using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDoctoresXamarin.Models
{
    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("DOCTOR_NO")]
        public int Id { get; set; }
        [Column("APELLIDO")]
        public String LastName { get; set; }
        [Column("ESPECIALIDAD")]
        public String Speciality { get; set; }
        [Column("SALARIO")]
        public int Salary { get; set; }
        [Column("HOSPITAL_COD")]
        public int Hospital { get; set; }
    }
}
