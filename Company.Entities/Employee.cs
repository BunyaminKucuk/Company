using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Entities
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId  { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeFirstName  { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeLastName  { get; set; }
        [Required]
        [StringLength(11)]
        public string EmployeePhone  { get; set; }
        [Required]
        public string EmployeeMail  { get; set; }
        [Required]
        public float EmployeeSalary  { get; set; }
        [Required]
        [ForeignKey("Task")]
        public int EmployeeTaskId  { get; set; }
    }
}
