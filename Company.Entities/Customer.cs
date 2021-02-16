using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Entities
{
    public class Customer
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId  { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerFirstName  { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerLastName  { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerAddress  { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerPhone  { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerEmail  { get; set; }
        [Required]
        [ForeignKey("Company")]
        public int CompanyId  { get; set; }
    }
}
